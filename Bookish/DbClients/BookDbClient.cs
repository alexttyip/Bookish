using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public static class BookDbClient
    {
        public static List<Book> GetAllBooks()
        {
            return Database.Instance.Connection.Query<Book>("SELECT * FROM Books;").ToList();
        }

        public static List<Book> GetAllBooksOrdered()
        {
            return Database.Instance.Connection.Query<Book>("SELECT * FROM Books ORDER BY title ASC;").ToList();
        }

        public static Book GetABook(int id)
        {
            return Database.Instance.Connection.Query<Book>("SELECT * FROM Books WHERE id = @id;", new { id }).First();
        }

        public static void InsertBook(Book book)
        {
            Database.Instance.Connection.Execute("INSERT INTO Books (title, ISBN) VALUES (@Title, @Isbn)", book);
        }
    }
}