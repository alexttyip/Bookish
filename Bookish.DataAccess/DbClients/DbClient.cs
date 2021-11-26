using System.Data.SqlClient;

namespace Bookish.DataAccess.DbClients
{
    public abstract class DbClient
    {
        protected readonly SqlConnection Conn;

        public DbClient(SqlConnection connection)
        {
            Conn = connection;
        }
    }
}