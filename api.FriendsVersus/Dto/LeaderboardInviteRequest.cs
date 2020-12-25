using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class LeaderboardInviteRequest
    {
        /*
        groupId:
        userId:
        oneTimeUse:
        timeExtent:*/
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public bool OneTimeUse { get; set; }
        public string TimeExtent { get; set; }

    }
}
