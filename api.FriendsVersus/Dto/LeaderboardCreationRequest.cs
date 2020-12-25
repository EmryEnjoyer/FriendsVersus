using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class LeaderboardCreationRequest
    {
        /*
         GroupName:
        DefaultMmr:
        Access:
        MaxMembers:
        creatorId:*/
        public string GroupName { get; set; }
        public int DefaultMmr { get; set; }
        public string Access { get; set; }
        public int MaxMembers { get; set; }
        public int CreatorId { get; set; }
    }
}
