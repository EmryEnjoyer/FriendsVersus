using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class User
    {
        /*userId:
        username:
        email:
        dateJoined:
        privileges:*/
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DateJoined { get; set; }
        public string Privileges { get; set; }
    }
}
