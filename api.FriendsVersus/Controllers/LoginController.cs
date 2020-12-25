using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : APIController
    {
        [HttpPost("token")]
        public async Task generateToken(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("forgotpassword")]
        public async Task forgotPassword(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("resetPassword")]
        public async Task resetPassword(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("{userId}/updateemail")]
        public async Task updateEmail([FromRoute] int userId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("revoketoken")]
        public async Task revokeToken(CancellationToken token) { 
        
        }
    }
}
