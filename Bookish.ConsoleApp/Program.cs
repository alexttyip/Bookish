﻿using System;
using Bookish.ConsoleApp.ConsoleServices;
using Bookish.DataAccess;
using Bookish.DataAccess.Services;

namespace Bookish.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Type `help` to show available commands.");

            var userService = UserServices.Instance;

            var bookConsoleServices = new BookConsoleServices(Database.Instance.Connection);
            var bookAuthorConsoleServices = new BookAuthorConsoleServices(Database.Instance.Connection);

            var runLoop = true;
            while (runLoop) {
                Console.Out.WriteLine();
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) {
                    Console.WriteLine("Enter in a proper command bro");
                    continue;
                }

                switch (input.ToLower()) {
                    case "sign in":
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
                    case "help":
                        Console.Out.WriteLine("Available command are: `sign in`, `list all books`, `list my books`, `search title`, `exit`, and `help` (this).");
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