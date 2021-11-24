using System;
using Bookish.DbClients;
using Bookish.Models;

namespace Bookish.Services
{
    public class UserServices
    {

        public static bool AuthenticateInputUser()
        {
            var username = Console.ReadLine();
            var password = Console.ReadLine();

            var pwHash = Utils.ComputeSha256(password);

            var inputUser = new User(username, pwHash);

            return AuthenticateUser(inputUser);
        }
        public static bool AuthenticateUser(User user)
        {
            User fetchedUser;
            try {
                fetchedUser = UserDbClient.GetAnUser(user.Username);
            }
            catch (UserDoesNotExistException) {
                return false;
            }

            return fetchedUser != null && user.Pw_hash == fetchedUser.Pw_hash;
        }
    }
}