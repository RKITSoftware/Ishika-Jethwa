using HRMSystem.Connection;
using MySql.Data.MySqlClient;
using System.Data;

namespace HRMSystem.DAL
{
    /// <summary>
    /// Data access class for interacting with the database table app01.
    /// </summary>
    public class DBAPP01Context
    {
        #region public method
        /// <summary>
        /// Get all applications for a job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <returns>A DataTable containing the applications for the specified job.</returns>
        public DataTable GetApplicationsForJob(int jobId)
        {
            DataTable dtResult = new DataTable();
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                string query = string.Format(@"SELECT 
                                        A01F01 as A01101,    
                                        A01F02 as A01102,
                                        A01F03 as A01103,
                                        A01F04 as A01104
                                    FROM 
                                        app01
                                    WHERE 
                                        A01F02 = {0}", jobId);
                MySqlCommand command = new MySqlCommand(query, objConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dtResult);
            }
            return dtResult;
        }

        /// <summary>
        /// Get an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <returns>A DataTable containing the application with the specified ID.</returns>
        public DataTable GetApplicationbyID(int id)
        {
            DataTable dtResult = new DataTable();
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                string query = string.Format(@"SELECT 
                                        A01F01 as A01101,    
                                        A01F02 as A01102,
                                        A01F03 as A01103,
                                        A01F04 as A01104
                                    FROM 
                                        app01
                                    WHERE 
                                        A01F01 = {0}", id);
                MySqlCommand command = new MySqlCommand(query, objConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dtResult);
            }
            return dtResult;
        }

        /// <summary>
        /// Get all records from the sta01 table.
        /// </summary>
        /// <returns>A DataTable containing all records from the sta01 table.</returns>
        public DataTable GetSta01Records()
        {
            DataTable dtResult = new DataTable();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                string query = @"SELECT 
                                        S01F01 as s01101,    
                                        S01F02 as s01102
                                    FROM 
                                        sta01";
                MySqlCommand command = new MySqlCommand(query, objConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dtResult);
            }

            return dtResult;
        }

        #endregion
    }
}
