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
    [Route("api/[controller]")]
    [ApiController]
    public class UserLeaderboardMembershipController : APIController
    {
        [HttpGet("{userId}/getleaderboards")]
        public async Task<IEnumerable<Leaderboard>> getUserLeaderboards([FromBody]ListUserLeaderboardsRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("joinleaderboard")]
        public async Task<LinkUserToLeaderboardResponse> joinLeaderboard([FromBody] LinkUserToLeaderboardRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{userId}/leaveLeaderboard")]
        public async Task<bool> leaveLeaderboard([FromBody]RemoveUserFromListRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{leaderboardId}/updateuserprivilege")]
        public async Task<bool> updateUserPrivilege([FromBody] UserLeaderboardPrivilegesUpdateRequest request, CancellationToken token)
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
