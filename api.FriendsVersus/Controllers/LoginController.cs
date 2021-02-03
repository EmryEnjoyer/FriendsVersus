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
    [Route("api/login")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LoginController : APIController
    {
        IConfiguration _config;
        IUserData _accessLayer;
        ITokenManager _tokenManager;
        public LoginController(ITokenManager tokenManager, IConfiguration config, IUserData accessLayer) : base(tokenManager)
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
        public async Task revokeToken([FromHeader(Name = "Authorization")] string accessToken, CancellationToken token) {
            if (await GetTokenIsRevoked())
                await _tokenManager.RevokeToken(accessToken.Replace("Bearer ", ""));
        }
    }
}
