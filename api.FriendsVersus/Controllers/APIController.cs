using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using api.FriendsVersus.Auth;

namespace api.FriendsVersus.Controllers
{
    public class APIController : ControllerBase
    {
        ITokenManager _tokenManager;
        public APIController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }
        [FromHeader(Name = "Authorize")]
        public string AuthToken { get; set; }

        protected async Task<bool> GetTokenIsRevoked()
        {
            string id = await _tokenManager.GetUserIdByTokenAsync(AuthToken.Replace("Bearer ", ""));
            return id != null;
        }
    }
}
