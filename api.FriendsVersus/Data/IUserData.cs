using api.FriendsVersus.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public interface IUserData
    {
        /// <summary>
        /// Creates a user and returns a UserCreationResponse
        /// </summary>
        /// <param name="request">The request for user creation</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>UserCreationResponse</returns>
        Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request, CancellationToken token);
        /// <summary>
        /// Sets IsAuthenticated to true and finalizes user creation
        /// </summary>
        /// <param name="request">The request for user authentication</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Completed user creation</returns>
        Task<UserCreationResponse> AuthenticateCreationAsync(UserEmailAuthenticationRequest request, CancellationToken token);
        /// <summary>
        /// Gets a user if one exists from the Users table
        /// </summary>
        /// <param name="_config">The appsettings.json file</param>
        /// <param name="username">Optional username</param>
        /// <param name="userId">Optional userid</param>
        /// <returns>User object</returns>
        Task<User> GetUserIfExists(IConfiguration _config, string? username=null, int? userId=null);
    }
}
