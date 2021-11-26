using System.Data.SqlClient;

namespace Bookish.ConsoleApp.ConsoleServices
{
    public abstract class ConsoleServicesBaseClass
    {
        protected SqlConnection Conn;

        protected ConsoleServicesBaseClass(SqlConnection conn)
        {
            Conn = conn;
        }
    }
}