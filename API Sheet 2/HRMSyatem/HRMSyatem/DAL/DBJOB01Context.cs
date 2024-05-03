using HRMSystem.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HRMSystem.DAL
{
    /// <summary>
    /// Class DBJob01 for Mysql operation on Job
    /// </summary>
    public class DBJOB01Context
    {
        #region Public Method
        /// <summary>
        /// Get all job details
        /// </summary>
        /// <returns>returns details of job in datatable</returns>
        public DataTable GetallJobs()
        {
            DataTable dtResult = new DataTable();
          
                using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
                {
                    //objConnection.Open();

                    string query = @"SELECT 
                                       B01F02 as B01102,
                                       B01F03 as B01103
                                  FROM 
                                       job01";
                    //objConnection.Close();
                    MySqlCommand command = new MySqlCommand(query, objConnection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    adapter.Fill(dtResult);
                }
            return dtResult;
        }

        /// <summary>
        /// Get job details by jobId
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public DataTable GetJobByID(int jobId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                string query = string.Format(@"SELECT    
                                       B01F02 as B01102,
                                       B01F03 as B01103
                                  FROM 
                                       job01
                                  WHERE 
                                       B01F01 = {0}", jobId);

                using (MySqlCommand objcmd = new MySqlCommand(query, objConnection))
                {
                    using (MySqlDataReader objReader = objcmd.ExecuteReader())
                    {
                        dataTable.Load(objReader);
                    }
                }
            }
            return dataTable;
        }

        #endregion

    }
}