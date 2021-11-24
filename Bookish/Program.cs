using System.Data.SqlClient;

namespace Bookish
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(@"Server=localhost;database=bookish;Trusted_Connection=true");
        }
    }
}