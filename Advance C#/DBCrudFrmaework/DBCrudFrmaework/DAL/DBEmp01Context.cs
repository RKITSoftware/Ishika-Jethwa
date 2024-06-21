using DBCrudFrmaework.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DBCrudFrmaework.DAL
{
    /// <summary>
    /// Database operations on Employee Table
    /// </summary>
    public class DBEmp01Context
    {

        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A list of DTO objects representing the employees.</returns>
        public DataTable GetAllEmployee()
        {
            DataTable dtResult = new DataTable();
           
                using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
                {
                    objConnection.Open();
                    string query = string.Format(@"SELECT 
                                        p01f01,    
                                        p01f02,
                                        p01f03,
                                        p01f04
                                    FROM 
                                        emp01");
                    MySqlCommand command = new MySqlCommand(query, objConnection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    adapter.Fill(dtResult);
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
            //if else enum operation through check
            //string str = string.Format(@"where p01f01 != {0}", id);
            DataTable dataTable = new DataTable();
         
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();
                string query = string.Format(@"SELECT 
                                        p01f01 as p01101,
                                        p01f02 as p01102,
                                        p01f03 as p01103,
                                        p01f04 as p01104
                                 FROM 
                                        emp01 
                                 WHERE 
                                        p01f01 = {0}", id);
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

    }
}
