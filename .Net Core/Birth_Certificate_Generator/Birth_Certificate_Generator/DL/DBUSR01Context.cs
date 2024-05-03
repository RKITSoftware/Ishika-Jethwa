using MySql.Data.MySqlClient;
using System.Data;

namespace Birth_Certificate_Generator.DL
{
    /// <summary>
    /// Data layer context for interacting with the USR01 (user) table in the database.
    /// </summary>
    public class DBUSR01Context
    {
        #region Private Member
        /// <summary>
        /// The database connection string used for MySql operations.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the DBUSR01Context with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public DBUSR01Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all user records from the USR01 table in the database.
        /// </summary>
        /// <returns>A DataSet containing all user records.</returns>
        public DataSet GetAllUser()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT 
                                         R01F01 as R01101,
                                         R01F02 as R01102,
                                         R01F03 as R01103,
                                         R01F05 as R01105 
                                 FROM 
                                         USR01"; 

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet; 
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves user records by their username from the USR01 table.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>A DataSet containing the user record with the specified username.</returns>
        public DataSet GetUserByUserName(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"SELECT 
                                                       R01F02 as R01102,
                                                       R01F03 as R01103,
                                                       R01F05 as R01105 
                                               FROM 
                                                        USR01
                                               WHERE 
                                                        R01F02 = '{0}'", username); 

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }

        #endregion
    }
}
