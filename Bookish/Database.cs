using System;
using System.Data.SqlClient;

namespace Bookish
{
    public class Database
    {
        private static readonly Lazy<Database> Lazy = new(() => new Database());


        public readonly SqlConnection Connection;

        private Database()
        {
            Connection = new SqlConnection(@"Server=localhost;database=bookish;Trusted_Connection=true");
        }

        public static Database Instance => Lazy.Value;
    }
}