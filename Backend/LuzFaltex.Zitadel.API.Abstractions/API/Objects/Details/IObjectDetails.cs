//
//  IObjectDetails.cs
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
using Remora.Rest.Core;

namespace LuzFaltex.Zitadel.API.Abstractions.API.Objects
{
    /// <summary>
    /// Provides information about an object, such as its creation date.
    /// </summary>
    public interface IObjectDetails
    {
        /// <summary>
        /// Gets the unique identifier of the latest change applied to this entity.
        /// </summary>
        /// <remarks>
        /// Can be compared against the sequence number from an update operation to ensure the object was updated.
        /// </remarks>
        Snowflake Sequence { get; }

        /// <summary>
        /// Gets the date and time that the object was created.
        /// </summary>
        DateTimeOffset CreationDate { get; }

        /// <summary>
        /// Gets the date and time of the last modification to this object.
        /// </summary>
        DateTimeOffset ChangeDate { get; }

        /// <summary>
        /// Gets the unique id of the organization this object belongs to.
        /// </summary>
        Snowflake ResourceOwner { get; }
    }
}
