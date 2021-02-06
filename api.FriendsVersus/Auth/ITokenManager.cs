using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Auth
{
    public interface ITokenManager
    {
        /// <summary>
        /// Returns a token with user information in it
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<string> GrantToken(string username);
        /// <summary>
        /// Returns a token with user information in it
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<string> GrantToken(int userId);
        /// <summary>
        /// Get the originator of a token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> GetUserIdByTokenAsync(string token);
        /// <summary>
        /// No longer recognize this token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task RevokeToken(string token);
    }
}
