//
//  IProfile.cs
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
    /// Information about a user for use in displaying their profile.
    /// </summary>
    [PublicAPI]
    public interface IProfile
    {
        /// <summary>
        /// Gets the user's first name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets the user's last name.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets the user's nickname.
        /// </summary>
        string NickName { get; }

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the user's language tag. Defined by <see href="https://tools.ietf.org/html/rfc3066"/>.
        /// </summary>
        string PreferredLanguage { get; }

        /// <summary>
        /// Gets a value indicating the user's gender.
        /// </summary>
        Gender Gender { get; }

        /// <summary>
        /// Gets the url to the user's avatar.
        /// </summary>
        string AvatarUrl { get; }
    }
}
