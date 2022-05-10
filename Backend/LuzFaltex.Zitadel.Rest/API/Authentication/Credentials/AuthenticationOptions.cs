//
//  AuthenticationOptions.cs
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

using System.IO;
using System.Text.Json;
using Remora.Rest.Core;

namespace LuzFaltex.Zitadel.Rest.API.Authentication.Credentials
{
    /// <inheritdoc />
    /// <param name="UserId">The unique id of this user.</param>
    /// <param name="KeyId">The unique id of the authentication key.</param>
    /// <param name="Key">The value of the authentication key.</param>
    public sealed record AuthenticationOptions(Snowflake UserId, Snowflake KeyId, string Key) : IAuthenticationOptions
    {
        /// <summary>
        /// Parses the json file at the provided path into an <see cref="AuthenticationOptions"/>.
        /// </summary>
        /// <param name="jsonPath">The path to the json file.</param>
        /// <returns>A new <see cref="AuthenticationOptions"/> built from the provided json file.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the specified json file could not be found.</exception>
        /// <exception cref="InvalidDataException">Thrown when the specified json file was found but could not be parsed.</exception>
        public static AuthenticationOptions FromJson(string jsonPath)
        {
            if (!Path.IsPathRooted(jsonPath))
            {
                jsonPath = Path.Join(Directory.GetCurrentDirectory(), jsonPath);
            }

            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException($"Could not locate the specified file.", jsonPath);
            }

            var options = JsonSerializer.Deserialize<AuthenticationOptions>(jsonPath, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return options ?? throw new InvalidDataException("The specified file yielded a 'null' result for deserialization.");
        }
    }
}
