using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public class UserData
    {

        private readonly string _connectionString;

        public UserData(IConfiguration config)
        {
            _connectionString = config.ThrowIfNull("Configuration").GetConnectionString("Appdata").ThrowIfNull("connectionString");
        }
    }
}
