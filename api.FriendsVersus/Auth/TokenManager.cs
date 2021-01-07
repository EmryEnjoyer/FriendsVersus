using api.FriendsVersus.Data;
using api.FriendsVersus.Dto;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.FriendsVersus.Auth
{
    public class TokenManager : ITokenManager
    {
        public IConfiguration _config;
        public IUserData _accessLayer;
        public TokenManager(IConfiguration config, IUserData access)
        {
            _config = config;
            _accessLayer = access;
        }

        /// <summary>
        /// Check for user by username or userId and return a JSON Token.
        /// </summary>
        /// <param name="username">Username to get user (Must be unique)</param>
        /// <param name="userId">UserId to get user (Must be unique</param>
        /// <returns>New JSON Token</returns>
        public async Task<string> GrantToken(string username)
        {
            User user;
            user = await (_accessLayer.GetUserIfExists(username));
            
            if (user != null)
            {
                return GenerateJSONToken(user, _config);
            }
            return null;
        }

        public async Task<string> GrantToken(int userId)
        {
            User user;
            user = await (_accessLayer.GetUserIfExists(userId));

            if (user != null)
            {
                return GenerateJSONToken(user, _config);
            }
            return null;
        }
        /*
          else
            {
                user = await (_accessLayer.GetUserIfExists(null, userId));
            }*/
        /// <summary>
        /// Constructs a new JWT Token from the User information
        /// </summary>
        /// <param name="user">User to generate token for</param>
        /// <param name="config">Configuration passed from startup</param>
        /// <returns></returns>
        private static string GenerateJSONToken(User user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("DateOfJoining", user.DateJoined),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
