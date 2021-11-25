using System;
using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class UserDbClient
    {
        public static List<User> GetAllUsers()
        {
            return Database.Instance.Connection.Query<User>("SELECT * FROM Users;").ToList();
        }

        public static User GetAUser(string username)
        {
            var users = Database.Instance.Connection.Query<User>("SELECT * FROM Users WHERE username = @username;", new { username }).ToList();

            try {
                return users.First();
            }
            catch (InvalidOperationException) {
                throw new UserDoesNotExistException();
            }
        }

        public static void InsertUser(User user)
        {
            Database.Instance.Connection.Execute("INSERT INTO Users (username, pw_hash) VALUES (@Username, @Pw_hash)", user);
        }

        public static List<LoanedBook> GetBooksLoanedByUser(User user)
        {
            const string query = @"
                    SELECT B.*, Bs.due
                    from Books B
                             join Book_statuses Bs
                                  on B.id = Bs.book_fk AND Bs.user_fk = 1
              ";

            return Database.Instance.Connection.Query<LoanedBook>(query).ToList();
        }
    }

    public class UserDoesNotExistException : Exception { }
}