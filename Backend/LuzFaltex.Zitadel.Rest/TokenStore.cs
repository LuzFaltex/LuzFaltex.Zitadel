//
//  TokenStore.cs
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

namespace LuzFaltex.Zitadel.Rest
{
    /// <inheritdoc />
    public class TokenStore : ITokenStore
    {
        /// <inheritdoc />
        public string Token { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenStore"/> class.
        /// </summary>
        /// <param name="token">The token to store.</param>
        public TokenStore(string token)
        {
            Token = token;
        }
    }
}