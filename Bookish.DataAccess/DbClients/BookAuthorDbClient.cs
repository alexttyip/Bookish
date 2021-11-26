using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Dapper;

namespace Bookish.DataAccess.DbClients
{
    public class BookAuthorDbClient : DbClient
    {
        public BookAuthorDbClient(SqlConnection conn) : base(conn) { }

        public List<BookAuthor> Search(string search)
        {
            const string query = @"
                select B.id    as BookId,
                       A.id    as AuthorId,
                       B.title as BookTitle,
                       A.name  as AuthorName,
                       B.ISBN  as ISBN
                from Books B
                         join Books_Authors BA on B.id = BA.book_id
                         RIGHT join Authors A on BA.author_id = A.id
                WHERE B.title LIKE @search
                   OR A.name LIKE @search;
            ";

            return Conn.Query<BookAuthor>(query, new { search = search + '%' }).ToList();
        }
    }
}