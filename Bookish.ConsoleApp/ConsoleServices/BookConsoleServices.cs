using System;
using System.Data.SqlClient;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookConsoleServices
    {
        private readonly SqlConnection _conn;

        public BookConsoleServices(SqlConnection conn)
        {
            _conn = conn;
        }

        public void ShowAllBooks()
        {
            var books = new BookServices(_conn).GetAllBooks();

            foreach(var book in books) Console.WriteLine(book.ToString());
        }

        public void ShowAllBooksOrdered()
        {
            var books = new BookServices(_conn).GetAllBooksOrdered();

            foreach(var book in books) Console.WriteLine(book.ToString());
        }
    }
}