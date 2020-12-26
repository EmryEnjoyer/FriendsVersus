using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class GameQueries
    {
        public static string getGameByIdQuery = @"
            SELECT
                GameId,
                LeaderboardId,
                PlayerOneId,
                PlayerTwoId,
                PlayerOneScore,
                PlayerTwoScore,
                Active,
                GameUrl,
                WinnerId
            FROM
                Games
            WHERE
                GameId = $GameId
        ";
        public static string insertGameQuery = @"
            INSERT INTO Games {
                LeaderboardId,
                PlayerOneId,
                PlayerTwoId,
                PlayerOneScore,
                PlayerTwoScore,
                GameUrl,
                IsActive
            } VALUES {
                $LeaderboardId,
                $PlayerOneId,
                $PlayerTwoId,
                $PlayerOneScore,
                $PlayerTwoScore,
                $GameUrl,
                $IsActive
            }
        ";
        public static string incrementScorePlayerOneQuery = @"
            UPDATE
                Games
            SET
                PlayerOneScore = PlayerOneScore + $Increment
            WHERE
                GameId = $GameId
        ";
        public static string incrementScorePlayerTwoQuery = @"
            UPDATE
                Games
            SET
                PlayerTwoScore = PlayerTwoScore + $Increment
            WHERE
                GameId = $GameId
        ";
        public static string setScorePlayerOneQuery = @"
            UPDATE
                Games
            SET
                PlayerOneScore = $PlayerOneScore
            WHERE
                GameId = $GameId
        ";
        public static string setScorePlayerTwoQuery = @"
            UPDATE
                Games
            SET
                PlayerTwoScore = $PlayerTwoScore
            WHERE
                GameId = $GameId
        ";
        public static string setIsActiveQuery = @"
            UPDATE
                Games
            SET
                IsActive = CASE WHEN 1 THEN 0 ELSE 1 END
            WHERE
                GameId = $GameId
        ";
        public static string setWinnerQuery = @"
            UPDATE
                Games
            SET
                WinnerId = $WinnderId
            WHERE
                GameId = $GameId
        ";
        public static string deleteGameQuery = @"
            DELETE FROM Games WHERE GameId = $GameId
        ";
    }
}
