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
    }
}