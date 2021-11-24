using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models;
using Dapper;

namespace Bookish.DbClients
{
    public class BookDbClient
    {
        private readonly SqlConnection _connection;

        public BookDbClient(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Book> GetAllBooks()
        {
            return _connection.Query<Book>("SELECT * FROM Books;").ToList();
        }

        public Book GetABook(int id)
        {
            return _connection.Query<Book>("SELECT * FROM Books WHERE id = @id;", new { id }).First();
        }

        public void InsertBook(Book book)
        {
            _connection.Execute("INSERT INTO Books (title, ISBN) VALUES (@title, @isbn)", book);
        }
    }
}