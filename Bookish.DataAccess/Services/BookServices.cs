using System.Collections.Generic;
using System.Data.SqlClient;
using Bookish.DataAccess.DbClients;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess.Services
{
    public class BookServices : ServicesBaseClass
    {
        public BookServices(SqlConnection conn) : base(conn) { }

        public List<Book> GetAllBooks()
        {
            return new BookDbClient(_conn).GetAllBooks();
        }

        public List<Book> GetAllBooksOrdered()
        {
            return new BookDbClient(_conn).GetAllBooksOrdered();
        }
    }
}