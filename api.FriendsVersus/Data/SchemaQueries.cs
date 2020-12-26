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
    }
}
