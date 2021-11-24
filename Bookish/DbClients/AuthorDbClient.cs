using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Authorish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class AuthorDbClient
    {
        public static List<Author> GetAllAuthors(SqlConnection conn)
        {
            return conn.Query<Author>("SELECT * FROM Authors;").ToList();
        }

        public static Author GetAnAuthor(SqlConnection conn, int id)
        {
            return conn.Query<Author>("SELECT * FROM Authors WHERE id = @id;", new { id }).First();
        }

        public static void InsertAuthor(SqlConnection conn, Author author)
        {
            conn.Execute("INSERT INTO Authors (name) VALUES (@Name)", author);
        }
    }
}