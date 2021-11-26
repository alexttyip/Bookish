using System.Collections.Generic;
using System.Data.SqlClient;
using Bookish.DataAccess.DbClients;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess.Services
{
    public class BookDetailsServices : ServicesBaseClass
    {
        private BookDetailsDbClient _dbClient;
        public BookDetailsServices(SqlConnection conn) : base(conn)
        {
            _dbClient = new BookDetailsDbClient(conn);
        }

        public List<BookDetails> GetBookDetails(int bookId)
        {
            return _dbClient.GetBookDetailsByBookId(bookId);
        }

        public void CreateBooks(string bookTitle, List<Author> authors, string isbn, int numCopies)
        {
            _dbClient.CreateBooks(bookTitle, authors, isbn, numCopies);
        }
    }
}