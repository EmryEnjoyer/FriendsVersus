using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.FriendsVersus.Auth;
using api.FriendsVersus.Data;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.FriendsVersus.Controllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : APIController
    {
        public IConfiguration _config;
        public IUserData accessLayer;
        public ITokenManager _tokenManager;
        public UserController(ITokenManager tokenManager, IConfiguration config, IUserData accessLayer) : base(tokenManager)
        {
            _config = config;
            _tokenManager = tokenManager;
            this.accessLayer = accessLayer;
        }
        /// <summary>
        /// Handles request to create user
        /// </summary>
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<UserCreationResponse> createUser([FromBody] UserCreationRequest request, CancellationToken token) {
            return await accessLayer.CreateUserAsync(request, token);
        }
        /// <summary>
        /// Handles request to authenticate user creation
        /// </summary>
        [HttpPut("Verify/{inviteLink}")]
        [AllowAnonymous]
        public async Task<TokenResponse> authenticateCreation([FromRoute] string inviteLink, CancellationToken token) {
            UserEmailAuthenticationRequest request = new UserEmailAuthenticationRequest()
            {
                InviteUrl = inviteLink
            };
            return await accessLayer.AuthenticateCreationAsync(request, _tokenManager, token);
        }
        /// <summary>
        /// Handles request to update username
        /// </summary>
        [HttpPut("{userId}/updateusername")]
        public async Task<bool> updateUsername([FromBody] UpdateUsernameRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Handles request to update the user admin privilege
        /// </summary>
        [HttpPut("{userId}/updatePrivileges")]
        public async Task<bool> updateUserPrivileges([FromRoute] int userId, UpdateUserAppPrivilegesRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// gets a list of users
        /// </summary>
        [HttpGet("users")]
        public async Task<IEnumerable<User>> listUsers(CancellationToken token) {
            return await accessLayer.GetUsers(token);
        }
        /// <summary>
        /// Handles request to get user
        /// </summary>
        [HttpGet("{userId}/get")]
        public async Task<User> getUser([FromRoute] int userId, CancellationToken token) {
            return await accessLayer.GetUserIfExists(userId);
        }
        /// <summary>
        /// Handles request to update user email
        /// </summary>
        [HttpPut("{userId}/updateemail")]
        public async Task<bool> UpdateEmail([FromRoute] int userId, [FromBody] UpdateEmailRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
    }   
}
