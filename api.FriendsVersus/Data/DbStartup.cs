using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
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
        /// <summary>
        /// sets up the database.
        /// </summary>
        /// <returns></returns>
        public async Task Startup() { 
            //Users
            using(SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUsersQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Leaderboards
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardsQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Challenges
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createChallengesQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Games
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createGamesQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserLeaderboardInteractions
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserLeaderboardInteractionsQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserMMRTable
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserMmrTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserVerificationLinks
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserVerificationLinkTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //LeaderboardInvitationLinks
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardInvitationTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserAuthenticationTokenTableQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUsersUsernameIndex);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUserVerificationIndexOnLink);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.setLeaderboardNameAsIndexQuery);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByAccepted);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByUserChallengedId);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByUserChallengerId);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
        }
    }
}
