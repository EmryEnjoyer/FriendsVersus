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
        public readonly string connectionString;
        public TokenManager(IConfiguration config, IUserData access)
        {
            _config = config;
            _accessLayer = access;
            connectionString = config.GetSection("connectionStrings")["AppData"];
            //connectionString = config.ThrowIfNull("Configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString");
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
                var token = GenerateJSONToken(user, _config);
                var hashToken = token.hashString();
                
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(UserQueries.authorizeUserQuery, connection);
                    command.Parameters.AddWithValue("$UserId", user.UserId);
                    command.Parameters.AddWithValue("$Token", hashToken);

                    await command.ExecuteScalarAsync();
                    connection.Close();
                }
                return token;
            }
            
            return null;
        }

        public async Task<string> GrantToken(int userId)
        {
            User user;
            user = await (_accessLayer.GetUserIfExists(userId));

            if (user != null)
            {
                var token = GenerateJSONToken(user, _config);
                var hashToken = token.hashString();
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqliteCommand command = new SqliteCommand(UserQueries.authorizeUserQuery, connection);
                    command.Parameters.AddWithValue("$UserId", user.UserId);
                    command.Parameters.AddWithValue("$Token", hashToken);

                    await command.ExecuteScalarAsync();
                    await connection.CloseAsync();
                }
                return token;
            }
            return null;
        }

        public async Task RevokeToken(string token)
        {
            using(SqliteConnection connection = new SqliteConnection(connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(UserQueries.deauthorizeUserQuery, connection);
                command.Parameters.AddWithValue("$Token", token.hashString());

                await command.ExecuteScalarAsync();

                await connection.CloseAsync();
            }
        }
        public async Task<string> GetUserIdByTokenAsync(string token)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(UserQueries.getUserIsAuthenticatedQuery, connection);
                command.Parameters.AddWithValue("$Token", token.hashString());

                SqliteDataReader reader = await command.ExecuteReaderAsync();

                await reader.ReadAsync();
                try
                {
                    if (await reader.IsDBNullAsync(0))
                    {
                        return null;
                    }
                    string result = reader.GetString(0);
                    await connection.CloseAsync();
                    return result;
                } catch(InvalidOperationException e)
                {
                    return null;
                }
                
            }
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
        private async Task<string> getTokenFromUserId(int userId) { 
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                await conn.OpenAsync();
                SqliteCommand command = new SqliteCommand(UserQueries.getTokenFromUserId, conn);
                command.Parameters.AddWithValue("$UserId", userId);
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                string s = reader.GetString(0);
                await conn.CloseAsync();
                return s;
            }
        }
    }
}
