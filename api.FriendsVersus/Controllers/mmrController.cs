using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.FriendsVersus.Auth;
using api.FriendsVersus.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/mmr")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MmrController : APIController
    {
        public MmrController(ITokenManager tokenManager) : base(tokenManager) { }
        [HttpPut("{userId}/updatemmr")]
        public async Task<bool> updateUserMmr([FromRoute] int userId, [FromBody] UpdateMMRRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
