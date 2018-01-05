using System.Data;

namespace EzMove.DataAcess
{
    public interface IConnectionManager
    {
        IDbConnection GetConnection();
    }
}
