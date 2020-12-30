using api.FriendsVersus.Data;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsVersusTests.Data_Tests
{
    [TestClass]
    public class LeaderboardsDBTest
    {
        public const string connectionString = "Data Source=D:/TestDBEnvironment/FriendsVersus/FriendsVersus.db;";
        [TestMethod]
        public void TestCanLeaderboardSchemaBeCreated()
        {
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(SchemaQueries.createLeaderboardsQuery, conn);
                command.ExecuteScalar();

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardIndexBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.setLeaderboardNameAsIndexQuery, conn);
                command.ExecuteScalar();

                conn.Close();
            }

        }
        [TestMethod]
        public void TestCanLeaderboardBeCreated()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.createLeaderboardQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardName", "Test1");
                command.Parameters.AddWithValue("$LeaderboardOwnerId", 1);
                command.ExecuteScalar();

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardBeGotByLeaderboardId()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.getLeaderboardByLeaderboardIdQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardId", 1);
                SqliteDataReader results = command.ExecuteReader();
                results.Read();
                Assert.AreEqual(results.GetString(1), "Test1");

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardBeGotByLeaderboardName()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.getLeaderboardByLeaderboardNameQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardName", "Test1");
                SqliteDataReader results = command.ExecuteReader();
                results.Read();
                Assert.AreEqual(results.GetInt32(0), 1);

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardNameBeGotByLeaderboardId()
        {
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.getLeaderboardNameByLeaderboardIdQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardId", 1);

                SqliteDataReader result = command.ExecuteReader();
                result.Read();
                Assert.AreEqual(result.GetString(0), "Test1");
                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardOwnerIdBeGotByLeaderboardId()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.getLeaderboardOwnerIdByLeaderboardIdQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardId", 1);

                SqliteDataReader result = command.ExecuteReader();
                result.Read();
                Assert.AreEqual(result.GetInt32(0), 1);
                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardNameBeUpdatedByLeaderboardId()
        {
            using(SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.updateLeaderboardNameByLeaderboardIdQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardName", "Test2");
                command.Parameters.AddWithValue("$LeaderboardId", 1);

                command.ExecuteScalar();

                SqliteCommand command2 = new SqliteCommand(LeaderboardQueries.getLeaderboardNameByLeaderboardIdQuery, conn);
                command2.Parameters.AddWithValue("$LeaderboardId", 1);

                SqliteDataReader result = command2.ExecuteReader();
                result.Read();
                Assert.AreEqual(result.GetString(0), "Test2");

                conn.Close();
            }
        }
        [TestMethod]
        public void TestCanLeaderboardBeDeleted() {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(LeaderboardQueries.deleteLeaderboardByLeaderboardIdQuery, conn);
                command.Parameters.AddWithValue("$LeaderboardId", 1);
                command.ExecuteScalar();
                conn.Close();
            }
        }
    }
}
