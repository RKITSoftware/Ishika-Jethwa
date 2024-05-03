using BCLLibrary;
using HRMSystem.Connection;
using HRMSystem.Helper;
using HRMSystem.Models;
using MySql.Data.MySqlClient;
using System;

namespace HRMSyatem.DAL
{
    /// <summary>
    /// DBLev01Context for Handling Leave 
    /// </summary>
    public class DBLEV01Context
    {
        /// <summary>
        /// Get All Leaves
        /// </summary>
        /// <returns></returns>
        public CustomList<LEV01> FetchAllLeavesFromDatabase()
        {
            CustomList<LEV01> leavesList = new CustomList<LEV01>();

            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                // SQL query with CASE WHEN...IN to convert enum-like codes into human-readable statuses
                string query = @"SELECT 
                            V01F01 as V01101,
                            V01F02 as V01102,
                            V01F03 as V01103,
                            V01F04 as V01104,
                            (CASE 
                                  WHEN (V01F05 = 'A') THEN 'Approved'
                                  WHEN (V01F05 = 'P') THEN 'Pending'
                                  WHEN (V01F05 = 'R') THEN 'Rejected'
                                  ELSE 'Unknown'
                             END) AS V01105
                         FROM 
                             lev01";

                MySqlCommand command = new MySqlCommand(query, objConnection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LEV01 leave = new LEV01
                        {
                            V01F01 = reader.GetInt32("V01101"), 
                            V01F02 = reader.GetString("V01102"),
                            V01F03 = reader.GetDateTime("V01103"),
                            V01F04 = reader.GetDateTime("V01104"),
                            V01F05 = reader.GetString("V01105") 
                        };

                        leavesList.Add(leave); // Add the item to the custom list
                    }
                }
            }

            return leavesList;
        }
    }
}