using api.FriendsVersus.Dto;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public Task<UserCreationResponse> AuthenticateCreationAsync(UserEmailAuthenticationRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserIfExists(IConfiguration _config, string? username = null, int? userId = null)
        {

            if (userId != null)
            {
                try
                {
                    using (SqliteConnection conn = new SqliteConnection(_config.ThrowIfNull("configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString")))
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
                    using (SqliteConnection conn = new SqliteConnection(_config.ThrowIfNull("configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString")))
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
