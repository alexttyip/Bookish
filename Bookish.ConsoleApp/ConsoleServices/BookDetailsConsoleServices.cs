using System;
using System.Data.SqlClient;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookDetailsConsoleServices : ConsoleServicesBaseClass
    {
        public BookDetailsConsoleServices(SqlConnection conn) : base(conn) { }

        public void ShowBookDetails()
        {
            Console.Out.Write("Enter book id for details: ");
            var bookIdString = Console.ReadLine();

            if (int.TryParse(bookIdString, out var bookId)) {
                var books = new BookDetailsServices(Conn).GetBookDetails(bookId);

                if (books.Count > 0) {
                    foreach(var book in books) Console.Out.WriteLine(book.ToString());
                    return;
                }
            }

            Console.Out.WriteLine("Enter a proper book id bro");
        }
    }
}