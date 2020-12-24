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
    [Route("api/leaderboard")]
    [ApiController]
    [Authorize]
    public class LeaderboardController : APIController
    {
        [HttpPost("create")]
        public async Task createLeaderboard(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpDelete("{leaderboardId}/delete")]
        public async Task deleteLeaderboard([FromRoute] int leaderboardId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{leaderboardId}/updatepositions")]
        public async Task updatePositions([FromRoute] int leaderboardId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("{leaderboardId}/get")]
        public async Task getPlayerById([FromRoute] int leaderboardId, [FromHeader] int UserId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("list")]
        public async Task listLeaderboards(CancellationToken token) {
            throw new NotImplementedException();
        }
    }
}
