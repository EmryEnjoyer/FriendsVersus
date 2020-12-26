using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class UserQueries
    {
        public static string getUserByUsernameQuery = @"
            SELECT
                UserId,
                Username,
                Email,
                DateJoined
            FROM
                Users
            WHERE
                Username = $Username";
        public static string getUserByUserIdQuery = @"
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
        public static string getPasswordQuery = @"
            SELECT
                Passwd
            FROM
                Users
            WHERE
                UserId = $UserId";
        public static string insertUserQuery = @"
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
        public static string updateUsernameQuery = @"
            UPDATE 
                Users
            SET
                Username = $Username
            WHERE
                UserId = $UserId
        ";
        public static string updatePasswordQuery = @"
            UPDATE
                Users
            SET
                Passwd = $Passwd
            WHERE
                UserId = $UserId
        ";
        public static string updateEmailQuery = @"
            UPDATE
                Users
            SET
                Email = $Email
            WHERE
                UserId = $UserId
        ";
        
        public static string deleteUserQuery = @"
        DELETE FROM
            Users
        WHERE
            UserId = $UserId
        ";

    }
}
