using System;
using System.Data.SqlClient;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookAuthorConsoleServices : ConsoleServicesBaseClass
    {
        public BookAuthorConsoleServices(SqlConnection conn) : base(conn) { }

        public void SearchTitles()
        {
            Console.Out.Write("Enter (part of) title: ");

            var title = Console.ReadLine();

            var books = new BookAuthorServices(Conn).Search(title);

            foreach(var book in books) Console.WriteLine(book.ToString());
        }
    }
}