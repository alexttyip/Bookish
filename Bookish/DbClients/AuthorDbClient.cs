using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class AuthorDbClient
    {
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