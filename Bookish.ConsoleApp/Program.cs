using System;
using Bookish.ConsoleApp.ConsoleServices;
using Bookish.DataAccess;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\nType `help` to show available commands.");

            var userService = UserServices.Instance;
            var conn = Database.Instance.Connection;

            var bookConsoleServices = new BookConsoleServices(conn);
            var bookAuthorConsoleServices = new BookAuthorConsoleServices(conn);
            var bookDetailsConsoleServices = new BookDetailsConsoleServices(conn);

            var runLoop = true;
            while (runLoop) {
                Console.Out.Write("\n>>> ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) {
                    Console.WriteLine("Enter in a proper command bro");
                    continue;
                }

                switch (input.ToLower()) {
                    case "login":
                        var authenticated = UserConsoleServices.AuthenticateUserWithInput();
                        Console.Out.WriteLine(authenticated ? "You're logged in!" : "Authentication failed.");
                        break;
                    case "list all books":
                        bookConsoleServices.ShowAllBooksOrdered();
                        break;
                    case "list my books":
                        if (userService.IsUserLoggedIn()) UserConsoleServices.PrintLoanedBooks();
                        else Console.Out.WriteLine("You're not logged in bro");
                        break;
                    case "search":
                        bookAuthorConsoleServices.SearchTitles();
                        break;
                    case "details":
                        bookDetailsConsoleServices.ShowBookDetails();
                        break;
                    case "create":
                        bookDetailsConsoleServices.CreateBooks();
                        break;
                    case "help":
                        var helpMessage = @"Available command are: `login`, `list all books`, `list my books`, `search`, `details`, `exit`, and `help` (this).";
                        Console.Out.WriteLine(helpMessage);
                        break;
                    case "exit":
                        runLoop = false;
                        break;
                    default:
                        Console.WriteLine("Enter in a proper command bro");
                        break;
                }
            }
        }
    }
}