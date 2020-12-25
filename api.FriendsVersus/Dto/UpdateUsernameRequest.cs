using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class UpdateUsernameRequest
    {
        public int UserId { get; set; }
        public string OldUsername { get; set; }
        public string NewUsername { get; set; }
    }
}
