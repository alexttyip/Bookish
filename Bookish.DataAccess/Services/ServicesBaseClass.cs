using System.Data.SqlClient;

namespace Bookish.DataAccess.Services
{
    public abstract class ServicesBaseClass
    {
        protected SqlConnection _conn;

        protected ServicesBaseClass(SqlConnection conn)
        {
            _conn = conn;
        }
    }
}