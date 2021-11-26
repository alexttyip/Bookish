using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class BookDetailsDbClient : DbClient
    {

        public BookDetailsDbClient(SqlConnection connection) : base(connection) { }

        public List<BookDetails> GetBookDetailsByBookId(int bookId)
        {
            const string sql = @"
                SELECT B.id       AS BookId,
                       A.id       AS AuthorId,
                       BS.id      AS CopyId,
                       B.title    AS BookTitle,
                       A.name     AS AuthorName,
                       B.ISBN     AS ISBN,
                       U.username AS Username,
                       BS.Due     AS Due
                FROM Books B
                         JOIN Book_statuses BS on B.id = BS.book_fk AND B.id = @bookId
                         LEFT JOIN Users U on BS.user_fk = U.id
                         LEFT JOIN Books_Authors BA ON B.id = BA.book_id
                         LEFT JOIN Authors A ON BA.author_id = A.id
            ";

            return Conn.Query<BookDetails>(sql, new { bookId }).ToList();
        }

        public void CreateBooks(string bookTitle, List<Author> authors, string isbn, int numCopies)
        {
            const string bookSql = @"INSERT INTO Books (title, ISBN) OUTPUT INSERTED.id VALUES (@bookTitle, @isbn);";
            var bookId = Conn.QuerySingle<int>(bookSql, new { bookTitle, isbn });

            const string authorSql = @"INSERT INTO Authors (name) OUTPUT INSERTED.id VALUES (@name)";
            const string bookAuthorSql = @"INSERT INTO Books_Authors (author_id, book_id) VALUES (@authorId, @bookId)";

            foreach(var author in authors) {
                try {
                    var authorId = Conn.QuerySingle<int>(authorSql, author);

                    Conn.Execute(bookAuthorSql, new { authorId, bookId });
                }
                catch (SqlException) { }
            }

            const string statusSql = @"INSERT INTO Book_Statuses (book_fk) Values (@bookId)";
            for (var i = 0; i < numCopies; i++) {
                Conn.Execute(statusSql, new { bookId });
            }
        }
    }
}