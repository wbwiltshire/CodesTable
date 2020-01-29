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

    public class UnitOfWork : IUOW
    {
        private readonly ILogger logger;
        private DBConnection dbc;
        private string CMDText;
        private int transactionCount;

        public UnitOfWork(DBConnection d, ILogger l)
        {
            logger = l;
            transactionCount = 0;
            dbc = d;
        }

        #region Enlist
        public async Task<bool> Enlist()
        {
            CMDText = "SET XACT_ABORT ON; BEGIN TRAN;";
            int rows;

            transactionCount++;
            //Begin transaction, if first time
            if (transactionCount == 1)
            {
                try
                {
                    //TODO: Do I need to check connection state here?
                    //ANSWER: No, if we don't have an open connection, we have bigger problems
                    //if (dbc.Connection.State != ConnectionState.Open)
                    //    await dbc.Open();

                    using (SqlCommand cmd = new SqlCommand(CMDText, dbc.Connection))
                    {
                        rows = await cmd.ExecuteNonQueryAsync();
                        logger.LogInformation("Enlisted in transaction");
                    }
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex.Message);
                }

            }
            return true;
        }
        #endregion

        #region Save
        public async Task<bool> Save()
        {
            CMDText = "COMMIT TRAN T1;";
            bool status = false;
            int rows;

            //TODO: Do I need to check connection state here?
            //ANSWER: No, if we don't have an open connection, we have bigger problems
            //if (dbc.Connection.State != ConnectionState.Open)
            //    await dbc.Open();

            //Nothing to do if no transactions have enlisted
            if (transactionCount > 0)
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand(CMDText, dbc.Connection))
                    {
                        rows = await cmd.ExecuteNonQueryAsync();
                        status = true;
                        transactionCount = 0;
                        logger.LogInformation("Save complete and unit of work committed.");
                    }
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            else
            {
                status = true;
                logger.LogInformation("Save ignored, because no transactions are enlisted.");
            }
            return status;
        }
        #endregion

        #region Rollback
        public async Task<bool> Rollback()
        {
            CMDText = "ROLLBACK TRAN;";
            bool status = false;
            int rows;

            //TODO: Do I need to check connection state here?
            //ANSWER: No, if we don't have an open connection, we have bigger problems
            //if (dbc.Connection.State != ConnectionState.Open)
            //    await dbc.Open();

            if (transactionCount > 0)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(CMDText, dbc.Connection))
                    {
                        rows = await cmd.ExecuteNonQueryAsync();
                        status = true;
                        transactionCount = 0;
                        logger.LogInformation("Rollback complete and unit of work cleared.");
                    }
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            else
            {
                status = true;
                logger.LogInformation("Rollback ignored, because no no transactions have enlisted.");
            }
            return status;
        }
        #endregion
    }

}
