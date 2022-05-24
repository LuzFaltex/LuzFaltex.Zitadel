//
//  ZitadelError.cs
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

namespace LuzFaltex.Zitadel.API.Abstractions.Results
{
    /// <summary>
    /// Enumerates various Zitadel error codes.
    /// </summary>
    [PublicAPI]
    public enum ZitadelError
    {
        /// <summary>
        /// Not an error; returned on success.
        /// </summary>
        OK = 0,

        /// <summary>
        /// The error could not be identified.
        /// </summary>
        Unknown = 2,

        /// <summary>
        /// The client specified an invalid argument.
        /// </summary>
        /// <remarks>
        /// This differs from <see cref="FailedPrecondition"/>.
        /// <see cref="InvalidArgument"/> indicates arguments that are
        /// problematic regardless of the state of the system (e.g. a malformed
        /// file name).
        /// </remarks>
        InvalidArgument = 3,

        /// <summary>
        /// The gateway timed out before the operation could complete.
        /// </summary>
        DeadlineExceeded = 4,

        /// <summary>
        /// The requested entity was not found.
        /// </summary>
        NotFound = 5,

        /// <summary>
        /// The entity that a client attempted to create already exists.
        /// </summary>
        AlreadyExists = 6,

        /// <summary>
        /// The caller does not have permission to execute the specified operation.
        /// </summary>
        PermissionDenied = 7,

        /// <summary>
        /// The operation was rejected because the system is not in a state
        /// required for the operation's execution.
        /// </summary>
        FailedPrecondition = 8,

        /// <summary>
        /// The operation is not implemented or is not supported/enabled in
        /// this service.
        /// </summary>
        Unimplemented = 12,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        /// <remarks>
        /// If you receive this error, contact Zitadel support.
        /// </remarks>
        Internal = 13,

        /// <summary>
        /// The service is currently unavailable.
        /// </summary>
        Unavailable = 14,

        /// <summary>
        /// The request does not have valid authentication credentials
        /// for this operation.
        /// </summary>
        Unauthenticated = 16
    }
}
