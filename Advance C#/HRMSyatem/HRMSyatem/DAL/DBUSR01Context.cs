using HRMSystem.Connection;
using MySql.Data.MySqlClient;
using System.Data;

namespace HRMSyatem.DAL
{
    /// <summary>
    /// Provides methods to retrieve user data from the 'usr01' table.
    /// </summary>
    public class DBUSR01Context
    {
        #region public method
        /// <summary>
        /// Retrieves all users from the 'usr01' table.
        /// </summary>
        /// <returns>A DataTable containing user data.</returns>
        public DataTable GetallUser()
        {
            DataTable dtResult = new DataTable();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                //objConnection.Open();

                string query = string.Format(@"select 
	                                                    R01F01,          
                                                        R01F02,     
                                                        R01F03,        
                                                        R01F05,       
                                                        P01F02,       
                                                        P01F03,        
                                                        P01F04  
                                                 from 
	                                                    vws_r01_p01");
                //objConnection.Close();
                MySqlCommand command = new MySqlCommand(query, objConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dtResult);
            }
            return dtResult;
        }

        /// <summary>
        /// Retrieves a user by their ID from the 'usr01' table.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>A DataTable containing user data for the specified user ID.</returns>
        public DataTable GetUserById(int userId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                string query = string.Format(@"select 
	                                                    R01F01,          
                                                        R01F02,     
                                                        R01F03,        
                                                        R01F05,       
                                                        P01F02,       
                                                        P01F03,        
                                                        P01F04  
                                                 from 
	                                                    vws_r01_p01
                                                 WHERE 
                                                        R01F01 = {0}", userId);

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