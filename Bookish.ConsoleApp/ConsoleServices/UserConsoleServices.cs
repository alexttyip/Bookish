using System;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public static class UserConsoleServices
    {
        public static bool AuthenticateUserWithInput()
        {
            Console.Out.Write("Username: ");
            var username = Console.ReadLine();
            Console.Out.Write("Password: ");
            var password = Console.ReadLine();

            if (username == null || password == null) return false;

            return UserServices.Instance.AuthenticateUserPlaintext(username, password);
        }

        public static void PrintLoanedBooks()
        {
            var loanedBooks = UserServices.Instance.GetLoanedBooks();

            foreach(var book in loanedBooks) Console.WriteLine($"{book.Id} - {book.Title} - {book.Isbn} - {book.Due}");
        }
    }
}