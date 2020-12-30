using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class LeaderboardQueries
    {
        public const string setLeaderboardNameAsIndexQuery = @"
            CREATE UNIQUE INDEX IF NOT EXISTS ix_LeaderboardNames
            ON Leaderboards(LeaderboardName)
        ";
        public const string createLeaderboardQuery = @"
            INSERT INTO Leaderboards (
                LeaderboardName,
                LeaderboardOwnerId
            ) VALUES (
                $LeaderboardName,
                $LeaderboardOwnerId
            )";
        public const string getLeaderboardByLeaderboardIdQuery = @"
            SELECT
                LeaderboardId,
                LeaderboardName,
                LeaderboardOwnerId
            FROM
                Leaderboards
            WHERE
                LeaderboardId = $LeaderboardId
        ";
        public const string getLeaderboardByLeaderboardNameQuery = @"
            SELECT
                LeaderboardId,
                LeaderboardName,
                LeaderboardOwnerId
            FROM
                Leaderboards
            WHERE
                LeaderboardName = $LeaderboardName
        ";
        public const string getLeaderboardNameByLeaderboardIdQuery = @"
            SELECT
                LeaderboardName
            FROM
                Leaderboards
            WHERE
                LeaderboardId = $LeaderboardId
        ";
        public const string getLeaderboardOwnerIdByLeaderboardIdQuery = @"
            SELECT
                LeaderboardOwnerId
            FROM
                Leaderboards
            WHERE
                LeaderboardId = $LeaderboardId
        ";
        public const string getLeaderboardOwnerIdByLeaderboardNameQuery = @"
            SELECT
                LeaderboardOwnerId
            FROM
                Leaderboards
            WHERE
                LeaderboardName = $LeaderboardName
        ";
        public const string updateLeaderboardNameByLeaderboardIdQuery = @"
            UPDATE
                Leaderboards
            SET
                LeaderboardName = $LeaderboardName
            WHERE
                LeaderboardId = $LeaderboardId
        ";
        public const string deleteLeaderboardByLeaderboardIdQuery = @"DELETE FROM Leaderboards WHERE LeaderboardId = $LeaderboardId";

    }
}
