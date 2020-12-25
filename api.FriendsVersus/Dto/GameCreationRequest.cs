using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Dto
{
    public class GameCreationRequest
    {
        int GameId { get; set; }
        int PlayerOneId { get; set; }
        int PlayerTwoId { get; set; }
        int LeaderboardId { get; set; }
    }
}
