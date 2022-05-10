//
//  ServiceCollectionExtensions.cs
//
//  Author:
//       LuzFaltex Contributors
//
//  Copyright (c) 2022 LuzFaltex
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LuzFaltex.Zitadel.Rest.API.Authentication.Credentials;
using LuzFaltex.Zitadel.Rest.Polly;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Remora.Rest.Extensions;
using Remora.Results;

namespace LuzFaltex.Zitadel.Rest.Extensions
{
    /// <summary>
    /// Defines various extension methods for the <see cref="IServiceCollection"/> interface.
    /// </summary>
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services required for Zitadel's REST API.
        /// </summary>
        /// <param name="serviceCollection">The service cllection.</param>
        /// <param name="authenticationOptionsFactory">A function that creates or retrieves the authorization token.</param>
        /// <param name="baseAddressFactory">A fucntion that creates or retrieves the base url. If not provided, defaults to <see cref="Constants.BaseUrl"/>.</param>
        /// <param name="buildClient">A function to allow additional modifications to the rest client.</param>
        /// <returns>The current <see cref="IServiceCollection"/>, for chaining.</returns>
        public static IServiceCollection AddZitadelRest
        (
            this IServiceCollection serviceCollection,
            Func<IServiceProvider, IAuthenticationOptions> authenticationOptionsFactory,
            Func<IServiceProvider, Uri>? baseAddressFactory = null,
            Action<IHttpClientBuilder>? buildClient = null
        )
        {
            serviceCollection.ConfigureZitadelJsonConverters();

            serviceCollection.AddSingleton(serviceProvider => authenticationOptionsFactory(serviceProvider));

            // Add API wrappers.

            // Add rest client
            var rateLimitPolicy = ZitadelRateLimitPolicy.Create();
            var retryDelay = Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5);

            var clientBuilder = serviceCollection
                .AddRestHttpClient<ResultError>("Zitadel")
                .ConfigureHttpClient((services, client) =>
                {
                    var assemblyName = Assembly.GetExecutingAssembly().GetName();
                    var name = assemblyName.Name ?? "LuzFaltex.Zitadel";
                    var version = assemblyName.Version ?? new Version(1, 0, 0);

                    var tokenStore = services.GetRequiredService<ITokenStore>();

                    client.BaseAddress = baseAddressFactory?.Invoke(services) ?? Constants.BaseUrl;
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(name, version.ToString()));

                    var authOptions = services.GetRequiredService<IAuthenticationOptions>();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                    (
                        scheme: "serviceaccount",
                        parameter: authOptions.ToAuthenticationToken(client.BaseAddress.AbsoluteUri)
                    );
                })
                .AddTransientHttpErrorPolicy
                (
                    b => b
                        .WaitAndRetryAsync(retryDelay)
                        .WrapAsync(rateLimitPolicy)
                )
                .AddPolicyHandler
                (
                    Policy
                        .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
                        .WaitAndRetryAsync
                        (
                            retryCount: 1,
                            sleepDurationProvider: (_, response, _) =>
                            {
                                if (response.Result == default)
                                {
                                    return TimeSpan.FromSeconds(1);
                                }

                                return response.Result.Headers.RetryAfter is null or { Delta: null }
                                            ? TimeSpan.FromSeconds(1)
                                            : response.Result.Headers.RetryAfter.Delta.Value;
                            },
                            onRetryAsync: (_, _, _, _) => Task.CompletedTask
                        )
                );

            // Run extra user-provided client building operations.
            buildClient?.Invoke(clientBuilder);

            return serviceCollection;
        }
    }
}
