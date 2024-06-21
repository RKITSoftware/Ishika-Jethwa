using MySql.Data.MySqlClient;
using System.Data;

namespace TimeTableGenerator.DL
{
    public class DbCommonContext
    {
        #region Private Members
        /// <summary>
        /// The database connection string used for MySql operations.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Constructor
        /// <summary>
        /// instance of the DBBCR01Context with the specified connection string.
        /// </summary>
        /// <param name="configuration">The connection string for the database.</param>
        public DbCommonContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        #endregion
        public DataSet Exec(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
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
    }
}
