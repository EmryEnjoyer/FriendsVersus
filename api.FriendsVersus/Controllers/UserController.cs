using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public async Task createUser(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{authToken}/authuser")]
        public async Task authenticateCreation([FromRoute] String authToken, CancellationToken token) {
        throw new NotImplementedException();
        }
        [HttpPut("{userId}/updateusername")]
        public async Task updateUsername([FromRoute] int userId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/updatePrivileges")]
        public async Task updateUserPrivileges([FromRoute] int userId, [FromHeader] String authHash, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("users")]
        public async Task listUsers(CancellationToken token) {
            throw new NotImplementedException();
        }

    }
}
