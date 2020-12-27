using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class SchemaQueries
    {
        public static string createUsersQuery = @"
            CREATE TABLE IF NOT EXISTS Users {
                UserId Integer PRIMARY KEY,
                Username Text,
                Password Text,
                Email Text,
                DateJoined Text,
                Banned Integer
            }
        ";
        public static string createGamesQuery = @"
            CREATE TABLE IF NOT EXISTS Games {
                GameId Integer PRIMARY KEY,
                LeaderboardId Integer,
                PlayerOneId Integer,
                PlayerTwoId Integer,
                PlayerOneScore Integer,
                PlayerTwoScore Integer,
                IsActive Integer
            }
        ";
        public static string createChallengesQuery = @"
            CREATE TAABLE IF NOT EXISTS Challenges {
                GameId Integer PRIMARY KEY,
                LeaderboardId Integer,
                ChallengerId Integer,
                ChallengedId Integer,
                ChallengerMmr Integer,
                ChallengedMmr Integer,
                Accepted Integer,
                InviteLink Text
            }
        ";
        public static string createLeaderboardsQuery = @"
            CREATE TABLE IF NOT EXISTS Leaderboards {
                LeaderboardId Integer PRIMARY KEY,
                LeaderboardName Text,
                LeaderboardOwnerId Integer
            }
        ";
    }
}
