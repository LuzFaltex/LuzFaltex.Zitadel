//
//  IUser.cs
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
using Remora.Rest.Core;

namespace LuzFaltex.Zitadel.API.Abstractions.API.Objects
{
    /// <summary>
    /// Represents a Zitadel user.
    /// </summary>
    [PublicAPI]
    public interface IUser
    {
        /// <summary>
        /// Gets the unique Id of the user.
        /// </summary>
        Snowflake Id { get; }

        /// <summary>
        /// Gets information about this object.
        /// </summary>
        IObjectDetails Details { get; }

        /// <summary>
        /// Gets the current state of the user. Default value is <see cref="UserState.Unspecified"/>.
        /// </summary>
        UserState State { get; }

        /// <summary>
        /// Gets the username of the user. This is not a unique value.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Gets a list of the fully-qualified login names used by the user.
        /// </summary>
        /// <example>List [ "gigi@caos.ch", "gigi@caos-ag.zitadel.ch" ].</example>
        string[] LoginNames { get; }

        /// <summary>
        /// Gets the user's preferred (primary) login name.
        /// </summary>
        string PreferredLoginName { get; }
    }
}
