using System.Data;

namespace EzMove.DataAcess
{
    public interface IDbHelper
    {
        void AddParameter(string parameterName, object value);
       
        void BeginTransaction();
        
        void CloseConnection();
        
        void CommitTransaction();

        void CreateCommand(string commandText);

        void CreateCommand(string commandText, CommandType commandType);

        DataSet ExecuteDataSet();

        int ExecuteNonQuery();

        IDataReader ExecuteReader();

        object ExecuteScalar();

        void OpenConnection();

        void RollbackTransaction();

        IDbConnection GetConnection();

        IDbCommand GetCommand(string commandText, CommandType commandType, IDbConnection currConnection);

        void AddParameter(string parameterName, object value, IDbCommand dbCommand);
    }
}
