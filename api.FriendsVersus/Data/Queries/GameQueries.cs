using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class GameQueries
    {
        public const string getGameByIdQuery = @"
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
        public const string insertGameQuery = @"
            INSERT INTO Games (
                GameId,
                ChallengerScore,
                ChallengedScore,
                IsActive
            ) VALUES (
                $GameId,
                $ChallengerScore,
                $ChallengedScore,
                $IsActive
            )
        ";
        public const string incrementScorePlayerOneQuery = @"
            UPDATE
                Games
            SET
                PlayerOneScore = PlayerOneScore + $Increment
            WHERE
                GameId = $GameId
        ";
        public const string incrementScorePlayerTwoQuery = @"
            UPDATE
                Games
            SET
                PlayerTwoScore = PlayerTwoScore + $Increment
            WHERE
                GameId = $GameId
        ";
        public const string setScorePlayerOneQuery = @"
            UPDATE
                Games
            SET
                PlayerOneScore = $PlayerOneScore
            WHERE
                GameId = $GameId
        ";
        public const string setScorePlayerTwoQuery = @"
            UPDATE
                Games
            SET
                PlayerTwoScore = $PlayerTwoScore
            WHERE
                GameId = $GameId
        ";
        public const string setIsActiveQuery = @"
            UPDATE
                Games
            SET
                IsActive = CASE WHEN 1 THEN 0 ELSE 1 END
            WHERE
                GameId = $GameId
        ";
        public const string setWinnerQuery = @"
            UPDATE
                Games
            SET
                WinnerId = $WinnderId
            WHERE
                GameId = $GameId
        ";
        public const string deleteGameQuery = @"
            DELETE FROM Games WHERE GameId = $GameId
        ";
    }
}
