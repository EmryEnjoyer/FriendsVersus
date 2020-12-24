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
    [Route("api/game")]
    [ApiController]
    [Authorize]
    public class GameController : APIController
    {
        [HttpPost("create")]
        public async Task createGame(CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPost("{gameId}/save")]
        public async Task saveGame([FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpGet("{gameId}/get")]
        public async Task getgame([FromRoute] int gameId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{gameId}/updatewinner")]
        public async Task updateWinner([FromRoute] int gameId, [FromHeader] String winner, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpPut("{gameId}/updatescore")]
        public async Task updateScore([FromRoute] int gameId, [FromHeader] int scorePlayer1, [FromHeader] int scorePlayer2, CancellationToken token) {
            throw new NotImplementedException();
        }
        [HttpDelete("{gameId}/delete")]
        public async Task deleteGame([FromRoute] int gameId, CancellationToken token) {
            throw new NotImplementedException();
        }

        [HttpPut("{userId}/updatewins")]
        public async Task updateUserWins([FromRoute] int userId, [FromHeader] int leaderboardId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/updatelosses")]
        public async Task updateUserLosses([FromRoute] int userId, [FromHeader] int leaderboardId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
