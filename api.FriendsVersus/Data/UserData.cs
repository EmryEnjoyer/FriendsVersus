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
            //_connectionString = config.ThrowIfNull("Configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString");
            _connectionString = config.GetSection("connectionStrings")["AppData"];
        }

        public Task<UserCreationResponse> AuthenticateCreationAsync(UserEmailAuthenticationRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request, CancellationToken token)
        {
            var sha256 = SHA256.Create();
            byte[] data = Encoding.ASCII.GetBytes(request.Password);
            var sha256Data = sha256.ComputeHash(data);
            string hashed = Encoding.ASCII.GetString(sha256Data);
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
                return Task.FromResult(new UserCreationResponse()
                {
                    RedirectUrl = "Friendsversus.net/" + Guid.NewGuid()
                });
            }
        }

        public async Task<User> GetUserIfExists(string? username = null, int? userId = null)
        {

            if (userId != null)
            {
                try
                {
                    using (SqliteConnection conn = new SqliteConnection(_connectionString))
                    {
                        conn.Open();
                        SqliteCommand command = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                        command.Parameters.AddWithValue("$UserId", userId);

                        SqliteDataReader results = command.ExecuteReader();
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
            }
            if(username != null)
            {
                try
                {
                    using (SqliteConnection conn = new SqliteConnection(_connectionString))
                    {
                        conn.Open();
                        SqliteCommand command = new SqliteCommand(UserQueries.getUserByUsernameQuery, conn);
                        command.Parameters.AddWithValue("$Username", username);

                        SqliteDataReader results = command.ExecuteReader();
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
            }
            return null;

        }

    }
}
