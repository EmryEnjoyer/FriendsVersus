using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class SchemaQueries
    {
        public const string createUsersQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                UserId Integer NOT NULL PRIMARY KEY,
                Username Text NOT NULL,
                Passwd Text NOT NULL,
                Email Text NOT NULL,
                DateJoined Integer NOT NULL,
                Banned Integer NOT NULL,
                IsAdmin Integer NOT NULL,
                IsVerified Integer NOT NULL
            )
        ";
        public const string createGamesQuery = @"
            CREATE TABLE IF NOT EXISTS Games (
                GameId Integer NOT NULL PRIMARY KEY,
                ChallengerScore Integer NOT NULL,
                ChallengedScore Integer NOT NULL,
                WinnerId Integer NULL,
                IsActive Integer NOT NULL,
                FOREIGN KEY (WinnerId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION,
                FOREIGN KEY (GameId) REFERENCES Challenges(GameId) ON DELETE CASCADE ON UPDATE NO ACTION
            ) WITHOUT ROWID
        ";
        public const string createChallengesQuery = @"
            CREATE TABLE IF NOT EXISTS Challenges (
                GameId Integer NOT NULL PRIMARY KEY,
                LeaderboardId Integer NOT NULL,
                ChallengerId Integer NOT NULL,
                ChallengedId Integer NOT NULL,
                Accepted Integer NOT NULL,
                FOREIGN KEY (LeaderboardId) REFERENCES Leaderboards(LeaderboardId) ON DELETE CASCADE ON UPDATE NO ACTION,
                FOREIGN KEY (ChallengerId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION,
                FOREIGN KEY (ChallengedId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION
            )
        ";
        public const string createLeaderboardsQuery = @"
            CREATE TABLE IF NOT EXISTS Leaderboards (
                LeaderboardId Integer NOT NULL PRIMARY KEY,
                LeaderboardName Text NOT NULL,
                LeaderboardOwnerId Integer NOT NULL,
                FOREIGN KEY (LeaderboardOwnerId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION
            )
        ";
        public const string createUserLeaderboardInteractionsQuery = @"
            CREATE TABLE IF NOT EXISTS UserLeaderboardInteractions (
                UserId Integer NOT NULL,
                LeaderboardId Integer NOT NULL,
                Wins Integer NOT NULL,
                Losses Integer NOT NULL,
                Role Text NOT NULL,
                Banned Integer NOT NULL,
                PRIMARY KEY(UserId, LeaderboardId),
                FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION,
                FOREIGN KEY (LeaderboardId) REFERENCES Leaderboards(LeaderboardId) ON DELETE CASCADE ON UPDATE NO ACTION
            ) WITHOUT ROWID
        ";
        public const string createUserMmrTableQuery = @"
            CREATE TABLE IF NOT EXISTS UserMmr (
                UserId Integer NOT NULL,
                LeaderboardId Integer NOT NULL,
                Mmr Integer NOT NULL,
                PRIMARY KEY (UserId, LeaderboardId),
                FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION,
                FOREIGN KEY (LeaderboardId) REFERENCES Leaderboards(LeaderboardId) ON DELETE CASCADE ON UPDATE NO ACTION
            ) WITHOUT ROWID
        ";

        public const string createUserVerificationLinkTableQuery = @"
            CREATE TABLE IF NOT EXISTS UserVerificationLinks (
                UserId Integer NOT NULL PRIMARY KEY,
                VerificationLink Text NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION
            ) WITHOUT ROWID
        ";
        public const string createLeaderboardInvitationTableQuery = @"
            CREATE TABLE IF NOT EXISTS LeaderboardInvites (
                LeaderboardId Integer NOT NULL PRIMARY KEY ,
                LeaderboardInviteLink Text NOT NULL,
                FOREIGN KEY (LeaderboardId) REFERENCES Leaderboards(LeaderboardId) ON DELETE CASCADE ON UPDATE NO ACTION
            )
        ";
        public const string createUserAuthenticationTokenTableQuery = @"
            CREATE TABLE IF NOT EXISTS Tokens {
                UserId Integer NOT NULL PRIMARY KEY,
                Token Text NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE NO ACTION
            ) WITHOUT ROWID";
    }
}
