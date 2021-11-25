using System;
using System.Data.SqlClient;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookAuthorConsoleServices
    {
        private readonly SqlConnection _conn;

        public BookAuthorConsoleServices(SqlConnection conn)
        {
            _conn = conn;
        }

        public void SearchTitles()
        {
            Console.Out.Write("Enter (part of) title: ");

            var title = Console.ReadLine();

            var books = new BookAuthorServices(_conn).Search(title);

            foreach(var book in books) Console.WriteLine(book.ToString());
        }
    }
}