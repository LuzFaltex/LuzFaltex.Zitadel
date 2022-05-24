//
//  UserState.cs
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

namespace LuzFaltex.Zitadel.API.Abstractions.API.Objects
{
    /// <summary>
    /// Describes the current state of the user.
    /// </summary>
    [PublicAPI]
    public enum UserState
    {
        /// <summary>
        /// No user state was specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The user is active and enabled.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The user has been disabled.
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// The user has been deleted.
        /// </summary>
        Deleted = 3,

        /// <summary>
        /// The user is locked out.
        /// </summary>
        Locked = 4,

        /// <summary>
        /// The user account is suspended.
        /// </summary>
        /// <remarks>
        /// This status is currently unused by the Zitadel API.
        /// </remarks>
        Suspend = 5,

        /// <summary>
        /// The user account has been created but is pending the first login of the user.
        /// </summary>
        Initial = 6
    }
}
