using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class BookDbClient
    {
        private readonly SqlConnection _conn;

        public BookDbClient(SqlConnection conn)
        {
            _conn = conn;
        }

        public List<Book> GetAllBooks()
        {
            return _conn.Query<Book>("SELECT * FROM Books;").ToList();
        }

        public List<Book> GetAllBooksOrdered()
        {
            return _conn.Query<Book>("SELECT * FROM Books ORDER BY title ASC;").ToList();
        }

        public Book GetABook(int id)
        {
            return _conn.Query<Book>("SELECT * FROM Books WHERE id = @id;", new { id }).First();
        }

        public void InsertBook(Book book)
        {
            _conn.Execute("INSERT INTO Books (title, ISBN) VALUES (@Title, @Isbn)", book);
        }
    }
}