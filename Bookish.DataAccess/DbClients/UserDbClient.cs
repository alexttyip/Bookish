using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class UserDbClient : DbClient
    {
        public UserDbClient(SqlConnection conn) : base(conn) { }

        public List<User> GetAllUsers()
        {
            return Conn.Query<User>("SELECT * FROM Users;").ToList();
        }

        public User GetAUser(string username)
        {
            var users = Conn.Query<User>("SELECT * FROM Users WHERE username = @username;", new { username }).ToList();

            try {
                return users.First();
            }
            catch (InvalidOperationException) {
                throw new UserDoesNotExistException();
            }
        }

        public void InsertUser(User user)
        {
            Conn.Execute("INSERT INTO Users (username, pw_hash) VALUES (@Username, @Pw_hash)", user);
        }

        public List<LoanedBook> GetBooksLoanedByUser(User user)
        {
            const string query = @"
                    SELECT B.*, Bs.due
                    from Books B
                             join Book_statuses Bs
                                  on B.id = Bs.book_fk AND Bs.user_fk = 1
              ";

            return Conn.Query<LoanedBook>(query).ToList();
        }
    }

    public class UserDoesNotExistException : Exception { }
}