using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class ChallengeCreationRequest
    {
        /*
         challengerName:
        challengedName:
        groupId:*/
        public string ChallengerName { get; set; }
        public string ChallengedName { get; set; }
        public int GroupId { get; set; }
    }
}
