using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class UserQueries
    {
        public const string getUserByUsernameQuery = @"
            SELECT
                UserId,
                Username,
                Email,
                DateJoined
            FROM
                Users
            WHERE
                Username = $Username";
        public const string getUserByUserIdQuery = @"
            SELECT
                UserId,
                Username,
                Email,
                DateJoined
            FROM
                Users
            WHERE
                UserId = $UserId
        ";
        public const string getPasswordQuery = @"
            SELECT
                Passwd
            FROM
                Users
            WHERE
                UserId = $UserId";
        public const string insertUserQuery = @"
            INSERT INTO Users {
                Username,
                Passwd,
                Email,
                DateJoined
            } VALUES {
                $Username,
                $Passwd,
                $Email,
                $DateJoined
            }";
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
        
        public const string deleteUserQuery = @"
        DELETE FROM
            Users
        WHERE
            UserId = $UserId
        ";

    }
}
