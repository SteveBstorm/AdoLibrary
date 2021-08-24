using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLibrary
{
    public class Connection
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _factory;

        public Connection(DbProviderFactory factory, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("'connectionString' n\'est pas valide");

            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            _connectionString = connectionString;
            _factory = factory;
        }

        public int ExecuteNonQuery(Command cmd)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command cmd, Func<IDataRecord, TResult> converter)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(Command cmd)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(Command cmd)
        {
            throw new NotImplementedException();
        }

        private DbConnection CreateConnection()
        {
            DbConnection dbConnection = _factory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;

            return dbConnection;
        }

        private static DbCommand CreateCommand(Command command, DbConnection dbConnection)
        {
            DbCommand sqlCommand = dbConnection.CreateCommand();
            sqlCommand.CommandText = command.Query;

            if (command.IsStoredProcedure)
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                DbParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = kvp.Key;
                sqlParameter.Value = kvp.Value;

                sqlCommand.Parameters.Add(sqlParameter);
            }

            return sqlCommand;
        }
    }
}
