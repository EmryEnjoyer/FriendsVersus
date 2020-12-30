using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class DbStartup
    {
        private readonly string _connectionString;
        public DbStartup(IConfiguration config)
        {
            _connectionString = config.
                ThrowIfNull("configuration").
                GetConnectionString("AppData").
                ThrowIfNull("connectionString");
        }

        public async Task Startup() { 
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUsersQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardsQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createChallengesQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createGamesQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserLeaderboardInteractionsQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserMmrTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserVerificationLinkTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardInvitationTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
        }
    }
}
