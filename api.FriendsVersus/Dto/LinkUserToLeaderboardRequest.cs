using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class LinkUserToLeaderboardRequest
    {
        public string Username { get; set; }
        public string LeaderboardInvite { get; set; }
    }
}
