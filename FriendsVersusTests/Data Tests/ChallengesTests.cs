using api.FriendsVersus.Data;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsVersusTests.Data_Tests
{
    [TestClass]
    public class ChallengesTests
    {
        public const string connectionString = "Data Source=D:/TestDBEnvironment/FriendsVersus/FriendsVersus.db;";
        [TestMethod]
        public void TestCanChallengeSchemaBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createChallengesQuery, conn);
                command.ExecuteScalar();

                conn.Close();
            }
        }
    }
}
