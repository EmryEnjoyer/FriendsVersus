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
    [Route("api/challenge")]
    [ApiController]
    [Authorize]
    public class ChallengeController : APIController
    {
        [HttpPost("create")]
        public async Task<ChallengeCreationResponse> createChallenge([FromBody] ChallengeCreationRequest request, CancellationToken token){
            throw new NotImplementedException();
        }
        
        [HttpGet("{gameId}/get")]
        public async Task<Challenge> getChallenge( [FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException(); 
        }
        [HttpGet("{gameId}/accept")]
        public async Task<bool> acceptChallenge([FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpDelete("{gameId}/delete")]
        public async Task<bool> deleteChallenge([FromRoute] int gameId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
