﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize]
    public class UserController : APIController
    {
        /// <summary>
        /// Handles request to create user
        /// </summary>
        [HttpPost("create")]
        public async Task<UserCreationResponse> createUser([FromBody] UserCreationRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Handles request to authenticate user creation
        /// </summary>
        [HttpPut("{authToken}/authuser")]
        public async Task<TokenResponse> authenticateCreation([FromBody] UserEmailAuthenticationRequest request, CancellationToken token) {
        throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Handles request to get user
        /// </summary>
        [HttpGet("{userId}/get")]
        public async Task<User> getUser([FromRoute] int userId, CancellationToken token) {
            throw new NotImplementedException();
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
