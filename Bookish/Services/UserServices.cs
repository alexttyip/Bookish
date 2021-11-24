using System;
using System.Data.SqlClient;
using Bookish.DbClients;
using Bookish.Models;

namespace Bookish.Services
{
    public class UserServices
    {

        public static bool AuthenticateInputUser(SqlConnection conn)
        {
            var username = Console.ReadLine();
            var password = Console.ReadLine();

            var pwHash = Utils.ComputeSha256(password);

            var inputUser = new User(username, pwHash);

           return AuthenticateUser(conn, inputUser);
        }
        public static bool AuthenticateUser(SqlConnection conn, User user)
        {
            User fetchedUser;
            try {
                fetchedUser = UserDbClient.GetAnUser(conn, user.Username);
            }
            catch (UserDoesNotExistException) {
                return false;
            }

            return fetchedUser != null && user.Pw_hash == fetchedUser.Pw_hash;
        }
    }
}