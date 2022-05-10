//
//  IZitadelRestUserAPI.cs
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LuzFaltex.Zitadel.API.Abstractions.API.Objects;
using Remora.Rest.Core;
using Remora.Results;

namespace LuzFaltex.Zitadel.API.Abstractions.API.Rest
{
    /// <summary>
    /// Represents the Zitadel User API.
    /// </summary>
    [PublicAPI]
    public interface IZitadelRestUserAPI
    {
        /// <summary>
        /// Gets the user object of the bot's account.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A retrieval result which may or may not have succeeded.</returns>
        Task<Result<IUser>> GetCurrentUserAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the user with the given id.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A retrieval result which may or may not have succeeded.</returns>
        Task<Result<IUser>> GetUserAsync(Snowflake userId, CancellationToken cancellationToken = default);
    }
}
