using api.FriendsVersus.Data;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FriendsVersusTests.Data_Tests
{
    [TestClass]
    public class UserDBTests
    {
        public const string connectionString = "Data Source=D:/TestDBEnvironment/FriendsVersus/FriendsVersus.db;";

        [TestMethod]
        public void TestAllWorksFine() {
            TestUserTableCanBeCreated();
            TestUsernameIndexCanBeCreated();
            TestUserCanBeCreated();
            TestUserCanBeGottenByUserId();
            TestUserCanBeGottenByUserName();
            TestCanPasswordBeGotByUserId();
            TestCanPasswordBeGotByUserName();
            TestUsernameCanBeUpdated();
            TestPasswordCanBeUpdated();
            TestCanUserEmailBeUpdated();
            TestUserCanBeDeleted();
        }

        [TestMethod]
        public void TestUserTableCanBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createUsersQuery, conn);
                command.ExecuteScalar();
                conn.Close();
            }
        }

        [TestMethod]
        public void TestUsernameIndexCanBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.createUsersUsernameIndex, conn);
                command.ExecuteScalar();
                conn.Close();
            }
        }

        [TestMethod]
        public void TestUserCanBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.insertUserQuery, conn);
                command.Parameters.AddWithValue("$Username", "Jerry");
                command.Parameters.AddWithValue("$Passwd", "Test2");
                command.Parameters.AddWithValue("$Email", "Test3");
                command.Parameters.AddWithValue("$DateJoined", "Test4");

                var result = command.ExecuteScalar();
                
                conn.Close();
            }
        }
        [TestMethod]
        public void TestUserCanBeGottenByUserId()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                command.Parameters.AddWithValue("$UserId", 1);

                SqliteDataReader result = command.ExecuteReader();
                if (result.Read())
                {
                    Assert.AreEqual(result.GetInt32(0), 1);
                }
                

                conn.Close();
            }
        }
        [TestMethod]
        public void TestUserCanBeGottenByUserName()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getUserByUsernameQuery, conn);
                command.Parameters.AddWithValue("$Username", "Test1");

                SqliteDataReader result = command.ExecuteReader();
                Assert.AreEqual(result.FieldCount, 4);

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanPasswordBeGotByUserId()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getPasswordByUserIdQuery, conn);
                command.Parameters.AddWithValue("$UserId", 1);

                SqliteDataReader result = command.ExecuteReader();
                Assert.AreEqual(result.FieldCount, 1);

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanPasswordBeGotByUserName()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.getPasswordByUsernameQuery, conn);
                command.Parameters.AddWithValue("$Username", "Test6");

                SqliteDataReader result = command.ExecuteReader();
                Assert.AreEqual(result.FieldCount, 1);

                conn.Close();
            }
        }
        [TestMethod]
        public void TestUsernameCanBeUpdated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.updateUsernameQuery, conn);
                command.Parameters.AddWithValue("$Username", "Test6");
                command.Parameters.AddWithValue("$UserId", 1);

                command.ExecuteScalar();
                SqliteCommand command2 = new SqliteCommand(UserQueries.getUserByUsernameQuery, conn);
                command2.Parameters.AddWithValue("$Username", "Test6");

                SqliteDataReader result = command2.ExecuteReader();
                if (result.Read())
                {
                    Assert.AreEqual(result.GetString(1), "Test6");
                }
                conn.Close();
            }
        }
        [TestMethod]
        public void TestPasswordCanBeUpdated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.updatePasswordQuery, conn);
                command.Parameters.AddWithValue("$Passwd", "Test7");
                command.Parameters.AddWithValue("$UserId", "0");

                command.ExecuteScalar();
                SqliteCommand command2 = new SqliteCommand(UserQueries.getPasswordByUserIdQuery, conn);
                command2.Parameters.AddWithValue("$UserId", "0");

                SqliteDataReader result = command2.ExecuteReader();
                if (result.Read())
                {
                    Assert.AreEqual(result.GetString(0), "Test7");
                }
                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanUserEmailBeUpdated() 
        { 
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.updateEmailQuery, conn);
                command.Parameters.AddWithValue("$Email", "Test8");
                command.Parameters.AddWithValue("$UserId", 1);
                command.ExecuteScalar();
                SqliteCommand command2 = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                command2.Parameters.AddWithValue("$UserId", 1);

                SqliteDataReader results = command2.ExecuteReader();
                if (results.Read())
                {
                    Assert.AreEqual(results.GetString(2), "Test8");
                }
                
                conn.Close();
            }
        }

        [TestMethod]
        public void TestCanUserPrivilegesBeUpdated()
        {
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.updateUserIsAdminQuery, conn);
                command.Parameters.AddWithValue("$UserId", 1);

                command.ExecuteScalar();

                SqliteCommand command2 = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                command2.Parameters.AddWithValue("$UserId", 1);

                SqliteDataReader result = command2.ExecuteReader();

                result.Read();

                Assert.AreEqual(result.GetInt32(5), 1);
                conn.Close();
            }
        }

        [TestMethod]
        public void TestCanUserBannedBeUpdated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.updateUserIsBannedQuery, conn);
                command.Parameters.AddWithValue("$UserId", 1);

                command.ExecuteScalar();

                SqliteCommand command2 = new SqliteCommand(UserQueries.getUserByUserIdQuery, conn);
                command2.Parameters.AddWithValue("$UserId", 1);

                SqliteDataReader result = command2.ExecuteReader();

                result.Read();

                Assert.AreEqual(result.GetInt32(4), 1);
                conn.Close();
            }
        }

        [TestMethod]
        public void TestUserCanBeDeleted() { 
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(UserQueries.deleteUserQuery, conn);
                command.Parameters.AddWithValue("$UserId", 1);

                command.ExecuteScalar();
                conn.Close();
            }
        }
    }
}
