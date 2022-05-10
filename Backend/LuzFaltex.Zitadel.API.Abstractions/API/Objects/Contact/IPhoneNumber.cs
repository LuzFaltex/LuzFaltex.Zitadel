//
//  IPhoneNumber.cs
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

namespace LuzFaltex.Zitadel.API.Abstractions.API.Objects
{
    /// <summary>
    /// Represents a phone number assigned to an object.
    /// </summary>
    public interface IPhoneNumber
    {
        /// <summary>
        /// Gets the phone number assigned to the object.
        /// </summary>
        /// <example>
        /// +41 71 000 00 00.
        /// </example>
        string Phone { get; }

        /// <summary>
        /// Gets a value indicating whether the user has verified the phone number.
        /// </summary>
        bool IsPhoneVerified { get; }
    }
}
