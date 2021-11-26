using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class AuthorDbClient : DbClient
    {
        public AuthorDbClient(SqlConnection conn) : base(conn) { }

        public  List<Author> GetAllAuthors()
        {
            return Conn.Query<Author>("SELECT * FROM Authors;").ToList();
        }

        public  Author GetAnAuthor(int id)
        {
            return Conn.Query<Author>("SELECT * FROM Authors WHERE id = @id;", new { id }).First();
        }

        public  void InsertAuthor(Author author)
        {
            Conn.Execute("INSERT INTO Authors (name) VALUES (@Name)", author);
        }
    }
}