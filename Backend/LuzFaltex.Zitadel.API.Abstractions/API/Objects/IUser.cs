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

namespace LuzFaltex.Zitadel.API.Abstractions.API.Objects
{
    /// <summary>
    /// Represents a Zitadel user.
    /// </summary>
    [PublicAPI]
    public interface IUser
    {
        /// <summary>
        /// Gets the Id of the user.
        /// </summary>
        public string Id { get; }

        // TODO: Add user information model

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the preferred login name of the user.
        /// </summary>
        public string PreferredLoginName { get; }

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the user's first name.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the user's last name.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets the url to the user's avatar.
        /// </summary>
        public string AvatarUrl { get; }
    }
}
