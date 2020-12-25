using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class UserEmailAuthenticationRequest
    {
        public string EmailAuthToken { get; set; }
        public string Password { get; set; }
    }
}
