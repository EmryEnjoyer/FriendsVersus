using api.FriendsVersus.Auth;
using api.FriendsVersus.Dto;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class UserData : IUserData
    {

        private readonly string _connectionString;

        public UserData(IConfiguration config)
        {
            _connectionString = config.ThrowIfNull("Configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString");
            //_connectionString = config.GetSection("connectionStrings")["AppData"];
        }



        public async Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request, CancellationToken token)
        {
            string hashed = request.Password.hashString();
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.insertUserQuery, conn);
                command.Parameters.AddWithValue("$Username", request.Username);
                command.Parameters.AddWithValue("$Passwd", hashed);
                command.Parameters.AddWithValue("$DateJoined", (Int32) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                command.Parameters.AddWithValue("$Email", request.Email);
                command.ExecuteScalar();
                conn.Close();

                string inviteId = Guid.NewGuid().ToString();
                UserCreationResponse response = new UserCreationResponse()
                {
                    RedirectUrl = $"Friendsversus.net/invites/{inviteId}"
                };
                int userId = await GetUserIdFromUsernameAsync(request.Username);

                await WriteUserInvitationLinkToLinkTableAsync(userId, inviteId);

                return response;

            }
        }

        public async Task<TokenResponse> AuthenticateCreationAsync(UserEmailAuthenticationRequest request, ITokenManager tokenManager, CancellationToken token)
        {
            try
            {
                using(SqliteConnection conn = new SqliteConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    SqliteCommand command = new SqliteCommand(UserQueries.getUserIdFromVerificationLink, conn);
                    command.Parameters.AddWithValue("$VerificationLink", request.InviteUrl);
                    var reader = await command.ExecuteReaderAsync();
                    await reader.ReadAsync();
                    User user = await GetUserIfExists(reader.GetInt32(0));
                    if (user != null)
                    {
                        SqliteCommand setUserIsVerified = new SqliteCommand(UserQueries.updateUserIsVerifiedQuery, conn);
                        setUserIsVerified.Parameters.AddWithValue("$UserId", user.UserId);
                        await setUserIsVerified.ExecuteScalarAsync(); 
                        await conn.CloseAsync();
                        return new TokenResponse(){
                            Token = await tokenManager.GrantToken(user.UserId)
                        };
                    }
                    await conn.CloseAsync();
                    return null;
                }
            } catch(SqliteException e)
            {
                return null;
            }
        }

        public async Task<User> GetUserIfExists(int userId)
        {

            
                try
                {
                    using (SqliteConnection conn = new SqliteConnection(_connectionString))
                    {
                        conn.Open();
                        SqliteCommand command = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                        command.Parameters.AddWithValue("$UserId", userId);

                        SqliteDataReader results = await command.ExecuteReaderAsync();
                        results.Read();
                        if (results.FieldCount > 0)
                        {
                            return new User
                            {
                                UserId = results.GetInt32(0),
                                Username = results.GetString(1),
                                Email = results.GetString(2),
                                DateJoined = results.GetString(3),
                                Banned = results.GetInt32(4),
                                IsAdmin = results.GetInt32(5)
                            };
                        }

                        conn.Close();
                    }
                }
                catch (SqliteException e)
                {
                    return null;
                }
            
            return null;

        }

        public async Task<User> GetUserIfExists(string username)
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    SqliteCommand command = new SqliteCommand(UserQueries.getUserByUsernameQuery, conn);
                    command.Parameters.AddWithValue("$Username", username);

                    SqliteDataReader results = await command.ExecuteReaderAsync();
                    results.Read();
                    if (results.FieldCount > 0)
                    {
                        return new User
                        {
                            UserId = results.GetInt32(0),
                            Username = results.GetString(1),
                            Email = results.GetString(2),
                            DateJoined = results.GetString(3),
                            Banned = results.GetInt32(4),
                            IsAdmin = results.GetInt32(5)
                        };
                    }

                    conn.Close();
                }
            }
            catch (SqliteException e)
            {
                return null;
            }
            return null;
            
        }
        public async Task<int> GetUserIdFromUsernameAsync(string username)
        {
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getUserIdByUsernameQuery, conn);
                command.Parameters.AddWithValue("$Username", username);
                SqliteDataReader reader = await command.ExecuteReaderAsync();
                reader.Read();
                var id = reader.GetInt32(0);
                conn.Close();


                return id;
                
            }
        }

        private async Task WriteUserInvitationLinkToLinkTableAsync(int userId, string inviteId)
        {
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUserVerificationLinkQuery, conn);
                command.Parameters.AddWithValue("$UserId", userId);
                command.Parameters.AddWithValue("$VerificationLink", inviteId);
                await command.ExecuteScalarAsync();
                conn.Close();
            }
        }

        public async Task<TokenResponse> AuthenticateUserAsync(UserLoginRequest request, ITokenManager tokenManager, CancellationToken token)
        {
            var hashedPassword = request.Password.hashString();
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getPasswordByUsernameQuery, conn);
                command.Parameters.AddWithValue("$Username", request.Username);
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                var pass = reader.GetString(0);
                conn.Close();
                if (pass == hashedPassword)
                {
                    return new TokenResponse()
                    {
                        Token = await tokenManager.GrantToken(request.Username)
                    };
                }
                throw new UnauthorizedAccessException();
             }
        }
    }
}
