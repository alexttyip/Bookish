using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class BookDbClient : DbClient
    {
        public BookDbClient(SqlConnection conn) : base(conn) { }

        public List<Book> GetAllBooks()
        {
            return Conn.Query<Book>("SELECT * FROM Books;").ToList();
        }

        public List<Book> GetAllBooksOrdered()
        {
            return Conn.Query<Book>("SELECT * FROM Books ORDER BY title ASC;").ToList();
        }

        public Book GetABook(int id)
        {
            return Conn.Query<Book>("SELECT * FROM Books WHERE id = @id;", new { id }).First();
        }

        public void InsertBook(Book book)
        {
            Conn.Execute("INSERT INTO Books (title, ISBN) VALUES (@Title, @Isbn)", book);
        }
    }
}