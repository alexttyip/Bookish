using System.Collections.Generic;
using System.Data.SqlClient;
using Bookish.DataAccess.DbClients;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess.Services
{
    public class BookAuthorServices
    {
        private readonly SqlConnection _conn;

        public BookAuthorServices(SqlConnection conn)
        {
            _conn = conn;
        }
        public List<BookAuthor> Search(string? searchTerm)
        {
            return new BookAuthorDbClient(_conn).Search(searchTerm ?? "");
        }
    }
}