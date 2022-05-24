//
//  AuthenticationOptionsExtensions.cs
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
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Jose;
using LuzFaltex.Zitadel.Rest.API.Authentication.Credentials;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace LuzFaltex.Zitadel.Rest.Extensions
{
    /// <summary>
    /// Contains extensions for the <see cref="AuthenticationOptions"/> class.
    /// </summary>
    public static class AuthenticationOptionsExtensions
    {
        /// <summary>
        /// Converts the <see cref="IAuthenticationOptions.Key"/> from the provided <paramref name="options"/> and parses it into an RSA token.
        /// </summary>
        /// <param name="options">The <see cref="IAuthenticationOptions"/>.</param>
        /// <param name="issuer">The issuer of the token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public static string ToAuthenticationToken(this IAuthenticationOptions options, string issuer)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(GetRSAParametersAsync(options));

            return JWT.Encode
                (
                    payload: new Dictionary<string, object>
                    {
                        { "iss", options.UserId },
                        { "sub", options.UserId },
                        { "iat", DateTimeOffset.UtcNow.AddSeconds(-1).ToUnixTimeSeconds() },
                        { "exp", DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds() },
                        { "aud", issuer }
                    },
                    key: rsa,
                    algorithm: JwsAlgorithm.RS256,
                    extraHeaders: new Dictionary<string, object>
                    {
                        { "kid", options.KeyId }
                    }
                );
        }

        private static RSAParameters GetRSAParametersAsync(IAuthenticationOptions options)
        {
            var bytes = Encoding.UTF8.GetBytes(options.Key);
            using var stream = new MemoryStream(bytes);
            using var reader = new StreamReader(stream);
            var pemReader = new PemReader(reader);

            if (pemReader.ReadObject() is not AsymmetricCipherKeyPair keyPair)
            {
                throw new InvalidCipherTextException("RSA Keypair could not be read.");
            }

            return DotNetUtilities.ToRSAParameters(keyPair.Private as RsaPrivateCrtKeyParameters);
        }
    }
}
