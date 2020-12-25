using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class Leaderboard
    {
        /*
        groupId:
        groupName:
        memberCount:
        dateCreated:
        defaultMmr:*/
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int MemberCount { get; set; }
        public string DateCreated { get; set; }
        public int DefaultMmr { get; set; }
    }
}
