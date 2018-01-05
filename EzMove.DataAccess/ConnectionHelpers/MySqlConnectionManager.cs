using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace EzMove.DataAcess
{
    public class MySqlConnectionManager : IConnectionManager
    {
        public IDbConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EZMoveConnectionString"].ConnectionString;
            return new MySqlConnection(connectionString);
        }
    }
}
