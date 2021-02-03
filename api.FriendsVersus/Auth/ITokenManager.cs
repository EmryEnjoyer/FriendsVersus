using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Auth
{
    public interface ITokenManager
    {
        Task<string> GrantToken(string username);
        Task<string> GrantToken(int userId);
        Task<string> GetUserIdByTokenAsync(string token);
        Task RevokeToken(string token);
    }
}
