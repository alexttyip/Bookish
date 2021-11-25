using System;
using Bookish.DbClients;

namespace Bookish.Services
{
    public class BookServices
    {
        public static void ShowAllBooks()
        {
            var books = BookDbClient.GetAllBooks();

            foreach(var book in books) Console.Out.WriteLine($"{book.Id} - {book.Title} - {book.Isbn}");
        }

        public static void ShowAllBooksOrdered()
        {
            var books = BookDbClient.GetAllBooksOrdered();

            foreach(var book in books) Console.Out.WriteLine($"{book.Id} - {book.Title} - {book.Isbn}");
        }
    }
}