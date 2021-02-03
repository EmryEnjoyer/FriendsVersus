using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class UserQueries
    {

        public const string createUsersUsernameIndex = @"
            CREATE UNIQUE INDEX IF NOT EXISTS uix_usernames
            ON Users(Username)
        ";
        public const string createUserVerificationIndexOnLink = @"
            CREATE INDEX IF NOT EXISTS uix_verificationLinks
            ON UserVerificationLinks(VerificationLink)
        ";

        public const string getUserByUsernameQuery = @"
            SELECT
                UserId,
                Username,
                Email,
                DateJoined,
                Banned,
                IsAdmin
            FROM
                Users
            WHERE
                Username = $Username";
        public const string getUserByUserIdQuery = @"
            SELECT
                UserId,
                Username,
                Email,
                DateJoined,
                Banned,
                IsAdmin
            FROM
                Users
            WHERE
                UserId = $UserId
        ";
        public const string getUserIdByUsernameQuery = @"
            SELECT
                UserId
            FROM
                Users
            WHERE
                Username = $Username
        ";
        public const string getPasswordByUserIdQuery = @"
            SELECT
                Passwd
            FROM
                Users
            WHERE
                UserId = $UserId";
        public const string getPasswordByUsernameQuery = @"
            SELECT
                Passwd
            FROM
                Users
            WHERE
                Username = $Username";
        public const string insertUserQuery = @"
            INSERT INTO Users (
                Username,
                Passwd,
                Email,
                DateJoined,
                Banned,
                IsAdmin,
                IsVerified
            ) VALUES (
                $Username,
                $Passwd,
                $Email,
                $DateJoined,
                0,
                0,
                0
            )";
        public const string updateUsernameQuery = @"
            UPDATE 
                Users
            SET
                Username = $Username
            WHERE
                UserId = $UserId
        ";
        public const string updatePasswordQuery = @"
            UPDATE
                Users
            SET
                Passwd = $Passwd
            WHERE
                UserId = $UserId
        ";
        public const string updateEmailQuery = @"
            UPDATE
                Users
            SET
                Email = $Email
            WHERE
                UserId = $UserId
        ";
        public const string updateUserIsAdminQuery = @"
            UPDATE
                Users
            SET
                IsAdmin = CASE IsAdmin WHEN 0 THEN 1 ELSE 0 END
            WHERE
                UserId = $UserId
        ";
        public const string updateUserIsBannedQuery = @"
            UPDATE
                Users
            SET
                Banned = CASE Banned WHEN 0 THEN 1 ELSE 0 END
            WHERE
                UserId = $UserId
        ";
        public const string updateUserIsVerifiedQuery = @"
            UPDATE
                Users
            SET
                IsVerified = CASE IsVerified WHEN 0 THEN 1 ELSE 0 END
            WHERE
                UserId = $UserId
        ";

        public const string deleteUserQuery = @"DELETE FROM Users WHERE UserId = $UserId";

        /*
         Authorization queries
         */
        public const string authorizeUserQuery = @"
            INSERT INTO Tokens (
                UserId,
                Token
            ) VALUES (
                $UserId,
                $Token
            )
        ";
        public const string getUserIsAuthenticatedQuery = @"
            SELECT UserId FROM Tokens WHERE Token = $Token
        ";
        public const string deauthorizeUserQuery = @"
            DELETE FROM Tokens WHERE Token = $Token
        ";
        /*
         User Creation Verification
        */
        public const string createUserVerificationLinkQuery = @"
            INSERT INTO UserVerificationLinks (
                UserId,
                VerificationLink
            ) VALUES (
                $UserId,
                $VerificationLink
            )
        ";

        public const string getUserIdFromVerificationLink = @"
            SELECT UserId FROM UserVerificationLinks WHERE VerificationLink=$VerificationLink
        ";
    }
}
