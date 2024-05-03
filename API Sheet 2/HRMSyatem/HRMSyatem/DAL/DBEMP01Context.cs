using HRMSystem.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HRMSystem.DAL
{ /// <summary>
  /// Database operations on Employee Table
  /// </summary>
    public class DBEMP01Context
    {
        #region Public method
        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A list of DTO objects representing the employees.</returns>
        public DataTable GetAllEmployee()
        {
            DataTable dtResult = new DataTable();
            try
            {
                using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
                {
                    objConnection.Open();
                    string query = @"SELECT 
                                        P01F01 as P01101,    
                                        P01F02 as P01102,
                                        P01F03 as P01103,
                                        P01F04 as P01104
                                    FROM 
                                        emp01";
                    MySqlCommand command = new MySqlCommand(query, objConnection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    adapter.Fill(dtResult);
                }
            }
            catch (Exception)
            {
                return dtResult;
            }
            return dtResult;
        }

        /// <summary>
        /// Retrieves a specific employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>A DTO object representing the employee details.</returns>
        public DataTable GetEmployeeByID(int id)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();
                string query = string.Format(@"SELECT 
                                        P01F01 as P01101,
                                        P01F02 as P01102,
                                        P01F03 as P01103,
                                        P01F04 as P01104
                                 FROM 
                                        emp01 
                                 WHERE 
                                        P01F01 = {0}", id);
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