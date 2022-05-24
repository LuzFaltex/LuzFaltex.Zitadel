//
//  RestRequestBuilderExtensions.cs
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

using JetBrains.Annotations;
using Polly;
using Remora.Rest;

namespace LuzFaltex.Zitadel.Rest.Extensions
{
    /// <summary>
    /// Defines extensions to the <see cref="RestRequestBuilder"/> class.
    /// </summary>
    [PublicAPI]
    public static class RestRequestBuilderExtensions
    {
        /// <summary>
        /// Sets up a Polly context with an endpoint for rate limiting purposes.
        /// </summary>
        /// <param name="builder">The request builder.</param>
        /// <param name="isExemptFromGlobalRateLimits">Whether this request is exempt from rate limits.</param>
        /// <returns>The current <see cref="RestRequestBuilder"/> for chaining.</returns>
        public static RestRequestBuilder WithRateLimitContext(this RestRequestBuilder builder, bool isExemptFromGlobalRateLimits = false)
        {
            var context = new Context
            {
                { "endpoint", builder.Endpoint },
                { "exempt-from-global-rate-limits", isExemptFromGlobalRateLimits }
            };

            builder.With(r => r.SetPolicyExecutionContext(context));

            return builder;
        }
    }
}
