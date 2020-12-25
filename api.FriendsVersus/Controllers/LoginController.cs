using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : APIController
    {
        [HttpPost("token")]
        public async Task<TokenResponse> generateToken([FromBody] UserLoginRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("{userId}/forgotpassword")]
        public async Task forgotPassword([FromRoute] int userId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("{userId}/resetPassword")]
        public async Task resetPassword([FromRoute] int userId, [FromBody] ResetPasswordRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("{userId}/updateemail")]
        public async Task updateEmail([FromRoute] int userId, [FromBody] UpdateEmailRequest request, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("revoketoken")]
        public async Task revokeToken(CancellationToken token) { 
        
        }
    }
}
