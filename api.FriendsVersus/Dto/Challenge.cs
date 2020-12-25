using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class Challenge
    {
        public int GameId { get; set; }
        public int ChallengerId { get; set; }
        public int ChallengedId { get; set; }
        public int LeaderboardId { get; set; }
        public string GameUrl { get; set; }
    }
}
