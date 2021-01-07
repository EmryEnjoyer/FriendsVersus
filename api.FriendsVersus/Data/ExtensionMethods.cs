using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public static class ExtensionMethods
    {
        public static T ThrowIfNull<T>(this T instance, string arg)
        {
            if (instance == null) throw new ArgumentNullException(arg);
            
            return instance;
        }
        /*
        public static bool TryGetValue(this SqliteDataReader reader, out object value)
        {


            return false;
        }
        */

        public static string hashString(this string instance)
        {
            var sha256 = SHA256.Create();
            byte[] data = Encoding.ASCII.GetBytes(instance);
            var sha256Data = sha256.ComputeHash(data);
            return Encoding.ASCII.GetString(sha256Data);
        }
    }
}
