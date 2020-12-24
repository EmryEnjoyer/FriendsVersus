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
    [Route("api/challenge")]
    [ApiController]
    [Authorize]
    public class ChallengeController : APIController
    {
        [HttpPost("create")]
        public async Task createChallenge([FromHeader] int challengerId, [FromHeader] int challengedId, CancellationToken token){
            throw new NotImplementedException();
        }
        
        [HttpGet("{gameId}/get")]
        public async Task getChallenge([FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("{gameId}/accept")]
        public async Task acceptChallenge([FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpDelete("{gameId}/delete")]
        public async Task deleteChallenge([FromRoute] int gameId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
