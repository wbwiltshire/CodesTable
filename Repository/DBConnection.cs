using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CodesTable.Data;
using CodesTable.Data.Interfaces;

namespace CodesTable.Data.Repository
{

    public class DBConnection : IDBConnection
    {
        private ILogger logger;
        private SqlConnection connection = null;
        private bool isOpen;

        //ctor
        public DBConnection(string connectionString, ILogger l)
        {
            logger = l;
            isOpen = false;
            try
            {
                connection = new SqlConnection(connectionString);
                logger.LogInformation($"ConnectionString: {connectionString}");
            }
            catch (SqlException ex)
            {
                logger.LogError(ex.Message);
            }
        }

        public SqlConnection Connection
        {
            get { return connection; }
        }

        #region Open
        public async Task<bool> Open()
        {
            //Only create a connection, if we don't already have one
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    await connection.OpenAsync();
                    isOpen = true;
                    logger.LogInformation("DBConnection opened.");
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            else
                logger.LogInformation("Using open DBConnection.");

            return isOpen;
        }
        #endregion

        #region Close
        public void Close()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    isOpen = false;
                    logger.LogInformation("DBConnection closed.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
        #endregion

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (connection != null)
                        connection.Close();
                    logger.LogInformation("DBConnection closed via dispose.");
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
