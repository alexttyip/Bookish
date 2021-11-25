using System;
using System.Collections.Generic;
using Bookish.DbClients;
using Bookish.Models;

namespace Bookish.Services
{
    public class UserServices
    {
        private static readonly Lazy<UserServices> Lazy = new(() => new UserServices());

        public User CurrentUser;

        private UserServices() { }

        public static UserServices Instance => Lazy.Value;

        public bool IsUserLoggedIn()
        {
            return CurrentUser != null;
        }

        public bool AuthenticateInputUser()
        {
            var username = Console.ReadLine();
            var password = Console.ReadLine();

            var pwHash = Utils.ComputeSha256(password);

            var inputUser = new User(username, pwHash);

            if (!AuthenticateUser(inputUser)) return false;

            CurrentUser = inputUser.Copy();
            return true;
        }

        public static bool AuthenticateUser(User user)
        {
            User fetchedUser;
            try {
                fetchedUser = UserDbClient.GetAUser(user.Username);
            }
            catch (UserDoesNotExistException) {
                return false;
            }

            return fetchedUser != null && user.Pw_hash == fetchedUser.Pw_hash;
        }

        public List<LoanedBook> GetLoanedBooks()
        {
            if (CurrentUser == null)
                throw new UnauthenticatedUserException();

            return UserDbClient.GetBooksLoanedByUser(CurrentUser);
        }
    }

    public class UnauthenticatedUserException : Exception { }
}