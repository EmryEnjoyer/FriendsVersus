using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class ChallengeQueries
    {
        public static string insertChallengeQuery = @"
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
    }
}
