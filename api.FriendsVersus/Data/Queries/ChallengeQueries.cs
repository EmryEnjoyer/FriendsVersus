using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class ChallengeQueries
    {
        /*
         Set Indexes
        */
        public const string setIndexByUserChallengerId = @"
            CREATE INDEX ix_ChallengerId
            ON Challenges(ChallengerId)
        ";

        //Insert Challenge Query
        public const string insertChallengeQuery = @"
            INSERT INTO Challenges {
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                ChallengerMMR,
                ChallengedMMR,
                Accepted
            } VALUES {
                $LeaderboardId,
                $ChallengerId,
                $ChallengedId,
                $ChallengerMMR,
                $ChallengedMMR,
                0
            }
        ";
        /*
         ----------------------------------------------------
         SELECTION QUERIES
         ----------------------------------------------------
         Select By Id
         Select All where User has been challenged
         Select All where User is challenger
         Select all where User accepted
         */
        public const string selectFromChallengesByGameId = @"
            SELECT
                GameId,
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            FROM
                Challenges
            WHERE
                GameId = $GameId
        ";
    }
}
