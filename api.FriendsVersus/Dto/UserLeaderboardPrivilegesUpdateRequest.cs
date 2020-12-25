using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class UserLeaderboardPrivilegesUpdateRequest
    {
        public int SenderId { get; set; }
        public int TargetId { get; set; }
        public string OldRole { get; set; }
        public string NewRole { get; set; }

    }
}
