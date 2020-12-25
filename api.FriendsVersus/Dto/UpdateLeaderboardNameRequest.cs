using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class UpdateLeaderboardNameRequest
    {
        public string LeaderboardId { get; set; }
        public string NewLeaderboardName { get; set; }
    }
}
