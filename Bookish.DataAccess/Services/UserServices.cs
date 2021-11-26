using System;
using System.Collections.Generic;
using Bookish.DataAccess.DbClients;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess.Services
{
    public class UserServices
    {
        private static readonly Lazy<UserServices> Lazy = new(() => new UserServices());

        public User? CurrentUser;
        private readonly UserDbClient _dbClient;

        private UserServices()
        {
            _dbClient = new UserDbClient(Database.Instance.Connection);
        }

        public static UserServices Instance => Lazy.Value;

        public bool IsUserLoggedIn()
        {
            return CurrentUser != null;
        }

        public bool AuthenticateUserPlaintext(string username, string password)
        {
            var pwHash = Utils.ComputeSha256(password);

            var inputUser = new User(username, pwHash);

            return AuthenticateUser(inputUser);
        }

        public bool AuthenticateUser(User user)
        {
            User fetchedUser;
            try {
                fetchedUser = _dbClient.GetAUser(user.Username);
            }
            catch (UserDoesNotExistException) {
                return false;
            }

            if (user.Pw_hash != fetchedUser.Pw_hash) return false;

            CurrentUser = user.Copy();
            return true;
        }

        public List<LoanedBook> GetLoanedBooks()
        {
            if (CurrentUser == null)
                throw new UnauthenticatedUserException();

            return _dbClient.GetBooksLoanedByUser(CurrentUser);
        }
    }

    public class UnauthenticatedUserException : Exception { }
}