using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.DataAccess.Models;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public class BookDetailsConsoleServices : ConsoleServicesBaseClass
    {
        private BookDetailsServices _services;
        public BookDetailsConsoleServices(SqlConnection conn) : base(conn)
        {
            _services = new BookDetailsServices(conn);
        }

        public void ShowBookDetails()
        {
            Console.Out.Write("Enter book id for details: ");
            var bookIdString = Console.ReadLine();

            if (int.TryParse(bookIdString, out var bookId)) {
                var books = _services.GetBookDetails(bookId);

                if (books.Count > 0) {
                    foreach(var book in books) Console.Out.WriteLine(book.ToString());
                    return;
                }
            }

            Console.Out.WriteLine("Enter a proper book id bro");
        }

        public void CreateBooks()
        {
            Console.Out.Write("Enter book title: ");
            var bookTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bookTitle)) {
                Console.Out.WriteLine("Please enter a book title.");
                return;
            }

            Console.Out.Write("Enter author names (case-sensitive, separated with commas): ");
            var authors = Console.ReadLine()?.Split(',').Select(name => new Author(name.Trim())).ToList();
            if (authors == null || !authors.Any()) {
                Console.Out.WriteLine("Please enter author names.");
                return;
            }

            Console.Out.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbn)) {
                Console.Out.WriteLine("Please enter a ISBN.");
                return;
            }

            Console.Out.Write("Enter number of copies: ");
            var numCopiesString = Console.ReadLine();
            if (!int.TryParse(numCopiesString, out var numCopies)) {
                Console.Out.WriteLine("Please enter number of copies.");
                return;
            }

            _services.CreateBooks(bookTitle, authors, isbn, numCopies);
        }
    }
}