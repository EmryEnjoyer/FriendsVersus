using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLeaderboardMembershipController : APIController
    {
        [HttpGet("{userId}/getleaderboards")]
        public async Task getUserLeaderboards([FromRoute] int userId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/joinleaderboard")]
        public async Task joinLeaderboard([FromRoute] int userId, [FromHeader] int leaderboardId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/leaveLeaderboard")]
        public async Task leaveLeaderboard([FromRoute] int userId, [FromHeader] int leaderboardId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{leaderboardId}/updateuserprivilege")]
        public async Task updateUserPrivilege([FromRoute] int leaderboardId, [FromHeader] int UserId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{leaderboardId}/banuser")]
        public async Task banUser([FromRoute] int leaderboardId, [FromHeader] int UserId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

    }
}
