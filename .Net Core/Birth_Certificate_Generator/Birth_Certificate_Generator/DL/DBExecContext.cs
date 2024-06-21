using MySql.Data.MySqlClient;
using System.Data;

namespace Birth_Certificate_Generator.DL
{
    public class DBExecContext
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
        public DBExecContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        #endregion
        public DataTable Exec(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataSet = new DataTable();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }
    }
}
