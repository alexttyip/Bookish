using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class AuthorDbClient
    {

        private SqlConnection _conn;

        public AuthorDbClient(SqlConnection conn)
        {
            _conn = conn;
        }

        public static List<Author> GetAllAuthors()
        {
            return Database.Instance.Connection.Query<Author>("SELECT * FROM Authors;").ToList();
        }

        public static Author GetAnAuthor(int id)
        {
            return Database.Instance.Connection.Query<Author>("SELECT * FROM Authors WHERE id = @id;", new { id }).First();
        }

        public static void InsertAuthor(Author author)
        {
            Database.Instance.Connection.Execute("INSERT INTO Authors (name) VALUES (@Name)", author);
        }
    }
}