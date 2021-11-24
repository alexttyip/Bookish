using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class UserDbClient
    {
        public static List<User> GetAllUsers(SqlConnection conn)
        {
            return conn.Query<User>("SELECT * FROM Users;").ToList();
        }

        public static User GetAnUser(SqlConnection conn, string username)
        {
            var users = conn.Query<User>("SELECT * FROM Users WHERE username = @username;", new { username }).ToList();

            try {
                return users.First();
            }
            catch (InvalidOperationException) {
                throw new UserDoesNotExistException();
            }
        }

        public static void InsertUser(SqlConnection conn, User user)
        {
            conn.Execute("INSERT INTO Users (username, pw_hash) VALUES (@Username, @Pw_hash)", user);
        }
    }

    public class UserDoesNotExistException : Exception { }
}