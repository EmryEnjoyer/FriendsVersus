using System;
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

        [HttpPost("create")]
        public async Task<UserCreationResponse> createUser([FromBody] UserCreationRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{authToken}/authuser")]
        public async Task<TokenResponse> authenticateCreation([FromBody] UserEmailAuthenticationRequest request, CancellationToken token) {
        throw new NotImplementedException();
        }
        [HttpPut("{userId}/updateusername")]
        public async Task<bool> updateUsername([FromBody] UpdateUsernameRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/updatePrivileges")]
        public async Task<bool> updateUserPrivileges([FromRoute] int userId, UpdateUserAppPrivilegesRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("users")]
        public async Task<IEnumerable<User>> listUsers(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("{userId}/get")]
        public async Task<User> getUser([FromRoute] int userId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/updateemail")]
        public async Task<bool> UpdateEmail([FromRoute] int userId, [FromBody] UpdateEmailRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
    }   
}
