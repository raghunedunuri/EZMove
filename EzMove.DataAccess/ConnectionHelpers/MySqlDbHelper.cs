using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace EzMove.DataAcess
{
    public class MySqlDbHelper : IDisposable, IDbHelper
    {
        #region Variables
        private IDbConnection connection;
        private IDbCommand command;
        #endregion

        #region Constructor
        public MySqlDbHelper(IConnectionManager connectionManager)
        {
            try
            {
                connection = connectionManager.GetConnection();                
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing MySqlDbHelper class.", ex);
            }
        }
        #endregion
        #region PublicMethods

        #region AddParameter
        /// <summary>
        /// Adds parameter to command
        /// </summary>
        /// <param name="parameterName"></param>        
        /// <param name="value"></param>
        public void AddParameter(string parameterName, object value)
        {
            MySqlParameter parameter = new MySqlParameter(parameterName, value);
            command.Parameters.Add(parameter);
        }
        #endregion

        #region BeginTransaction
        /// <summary>
        /// Opens the database connection and begins transaction
        /// </summary>
        public void BeginTransaction()
        {
            OpenConnection();
            connection.BeginTransaction();
        }
        #endregion

        #region CloseConnection
        /// <summary>
        /// Closes the connection to the data source
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region CommitTransaction
        /// <summary>
        /// Commits the transaction
        /// </summary>
        public void CommitTransaction()
        {
            command.Transaction.Commit();
            CloseConnection();
        }
        #endregion

        #region CreateCommand
        /// <summary>
        /// Create command object
        /// </summary>
        /// <param name="commandText"></param>
        public void CreateCommand(string commandText)
        {
            CreateCommand(commandText, CommandType.Text);
        }
        #endregion

        #region CreateCommand
        /// <summary>
        /// Create command object
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        public void CreateCommand(string commandText, CommandType commandType)
        {
            OpenConnection();

            command = new MySqlCommand(commandText, connection as MySqlConnection) { CommandType = commandType};
            command.CommandTimeout = 120;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Closes the connection and disposes connection and command object
        /// </summary>
        public void Dispose()
        {
            try
            {
                // Dispose off connection object
                if (connection != null)
                {
                    CloseConnection();
                    connection.Dispose();
                }

                // Clean Up Command Object
                if (command != null)
                {
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error disposing MySqlHelper class.", ex);
            }
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// Executes an SQL statement and returns the dataset.
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteDataSet()
        {
            try
            {
                MySqlDataAdapter adpt = new MySqlDataAdapter(command as MySqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// Executes an SQL statement and returns the number of rows affected.
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// Executes an SQL statement and returns the data reader.
        /// </summary>        
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            try
            {
                return command.ExecuteReader();
            }
            catch
            {
                CloseConnection();
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query.
        /// Additional columns or rows are ignored.
        /// </summary>        
        /// <returns></returns>
        public object ExecuteScalar()
        {
            try
            {
                return command.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region OpenConnection
        /// <summary>
        /// Opens the database connection
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to the database.", ex);
            }
        }
        #endregion

        #region RollbackTransaction
        /// <summary>
        /// Rollbacks the connection
        /// </summary>
        public void RollbackTransaction()
        {
            command.Transaction.Rollback();
            CloseConnection();
        }
        #endregion

        #endregion
    }
}
