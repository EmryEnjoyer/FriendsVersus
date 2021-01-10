using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.FriendsVersus.Auth;
using api.FriendsVersus.Data;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.FriendsVersus.Controllers
{
    [Route("api/login")]
    [ApiController]
    [Authorize]
    public class LoginController : APIController
    {
        IConfiguration _config;
        IUserData _accessLayer;
        ITokenManager _tokenManager;
        public LoginController(IConfiguration config, IUserData accessLayer, ITokenManager tokenManager)
        {
            _config = config;
            _accessLayer = accessLayer;
            _tokenManager = tokenManager;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<TokenResponse> generateToken([FromBody] UserLoginRequest request, CancellationToken token) {
            return await _accessLayer.AuthenticateUserAsync(request, _tokenManager, token);
        }
        [AllowAnonymous]
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
