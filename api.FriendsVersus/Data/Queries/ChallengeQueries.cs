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
        public const string setIndexByUserChallengedId = @"
            CREATE INDEX ix_ChallengedId
            ON Challenges(ChallengedId)
        ";
        public const string setIndexByAccepted = @"
            CREATE INDEX ix_Accepted
            ON Challenges(Accepted)
        ";

        //Insert Challenge Query
        public const string insertChallengeQuery = @"
            INSERT INTO Challenges {
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            } VALUES {
                $LeaderboardId,
                $ChallengerId,
                $ChallengedId,
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
        public const string selectFromChallengesByUserIsChallenger = @"
            SELECT
                GameId,
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            FROM
                Challenges
            WHERE
                ChallengerId = $ChallengerId
        ";
        public const string selectFromChallengesByUserIsChallenged = @"
            SELECT
                GameId,
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            FROM
                Challenges
            WHERE
                ChallengedId = $ChallengedId
        ";
        public const string selectFromChallengesByUserIdDidAccept = @"
            SELECT
                GameId,
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            FROM
                Challenges
            WHERE
                ChallengedId = $ChallengedId,
                Accepted = 1
        ";
        public const string selectFromChallengesByUserChallengedUser = @"
            SELECT
                GameId,
                LeaderboardId,
                ChallengerId,
                ChallengedId,
                Accepted
            FROM
                Challenges
            WHERE
                ChallengedId = $ChallengedId,
                ChallengerId = $ChallengerId
        ";
    }
}
