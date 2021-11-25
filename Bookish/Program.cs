using System;
using Bookish.Services;

namespace Bookish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookServices.ShowAllBooksOrdered();

            Console.Out.WriteLine();

            var userServices = UserServices.Instance;

            userServices.AuthenticateInputUser();

            if (userServices.IsUserLoggedIn()) {
                Console.Out.WriteLine("You're logged in!");

                var loanedBooks = userServices.GetLoanedBooks();
                foreach(var loanedBook in loanedBooks) {
                    Console.Out.WriteLine(loanedBook.Title);
                    Console.Out.WriteLine(loanedBook.Due);
                }
            }
            else {
                Console.Out.WriteLine("Bad luck");
            }
        }
    }
}