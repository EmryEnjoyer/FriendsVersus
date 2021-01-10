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
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUsersQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Leaderboards
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardsQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Challenges
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createChallengesQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //Games
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createGamesQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserLeaderboardInteractions
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserLeaderboardInteractionsQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserMMRTable
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserMmrTableQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //UserVerificationLinks
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserVerificationLinkTableQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            //LeaderboardInvitationLinks
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardInvitationTableQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUserAuthenticationTokenTableQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUsersUsernameIndex, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUserVerificationIndexOnLink, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.setLeaderboardNameAsIndexQuery, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByAccepted, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByUserChallengedId, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(ChallengeQueries.setIndexByUserChallengerId, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUsersUsernameIndex, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUserVerificationIndexOnLink, conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }

        }
    }
}
