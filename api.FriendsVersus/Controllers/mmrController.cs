using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.FriendsVersus.Controllers
{
    [Route("api/mmr")]
    [ApiController]
    public class mmrController : APIController
    {
        
        [HttpPut("{userId}/updatemmr")]
        public async Task updateUserMmr([FromRoute] int userId, [FromHeader] int leaderboardId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
