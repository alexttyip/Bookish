using System.Collections.Generic;
using System.Data.SqlClient;
using Bookish.DataAccess.DbClients;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess.Services
{
    public class BookDetailsServices : ServicesBaseClass
    {
        public BookDetailsServices(SqlConnection conn) : base(conn) { }

        public List<BookDetails> GetBookDetails(int bookId)
        {
            return new BookDetailsDbClient(_conn).GetBookDetailsByBookId(bookId);
        }
    }
}