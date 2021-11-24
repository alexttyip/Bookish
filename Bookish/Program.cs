using System;
using System.Data.SqlClient;
using Bookish.Services;

namespace Bookish
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new SqlConnection(@"Server=localhost;database=bookish;Trusted_Connection=true");

            Console.Out.WriteLine(UserServices.AuthenticateInputUser(conn).ToString());
        }
    }
}