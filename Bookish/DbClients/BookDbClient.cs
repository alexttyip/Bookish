using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class BookDbClient
    {
        public static List<Book> GetAllBooks(SqlConnection conn)
        {
            return conn.Query<Book>("SELECT * FROM Books;").ToList();
        }

        public static Book GetABook(SqlConnection conn, int id)
        {
            return conn.Query<Book>("SELECT * FROM Books WHERE id = @id;", new { id }).First();
        }

        public static void InsertBook(SqlConnection conn, Book book)
        {
            conn.Execute("INSERT INTO Books (title, ISBN) VALUES (@Title, @Isbn)", book);
        }
    }
}