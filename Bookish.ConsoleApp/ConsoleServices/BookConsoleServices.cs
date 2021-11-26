using System;
using System.Data.SqlClient;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookConsoleServices : ConsoleServicesBaseClass
    {
        public BookConsoleServices(SqlConnection conn) : base(conn) { }

        public void ShowAllBooks()
        {
            var books = new BookServices(Conn).GetAllBooks();

            foreach(var book in books) Console.WriteLine(book.ToString());
        }

        public void ShowAllBooksOrdered()
        {
            var books = new BookServices(Conn).GetAllBooksOrdered();

            foreach(var book in books) Console.WriteLine(book.ToString());
        }
    }
}