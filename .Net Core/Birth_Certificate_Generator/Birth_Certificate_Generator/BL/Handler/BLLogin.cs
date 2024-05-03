using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using MySql.Data.MySqlClient;
using System.Data;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Handler class for managing user-related operations, such as login and user validation.
    /// </summary>
    public class BLLogin
    {
        #region Private Member
        /// <summary>
        /// Connection string for database operations.
        /// </summary>
        private readonly string _configuration;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the BLLogin class, setting up the configuration and database connection string.
        /// </summary>
        public BLLogin()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            _configuration = configuration.GetConnectionString("Default"); 
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A DataSet containing all user records.</returns>
        public DataSet GetUser()
        {
            using (MySqlConnection connection = new MySqlConnection(_configuration))
            {
                string query = @"SELECT 
                                         R01F01,  
                                         R01F02,   
                                         R01F03,   
                                         R01F04,   
                                         R01F05    
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
        /// Validates a user based on the provided username and password.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password associated with the username.</param>
        /// <returns>The validated user or null if the user is invalid.</returns>
        public USR01 ValidateUser(string username, string password)
        {
            List<USR01> users = GetUser().DatasetToList<USR01>(); // Convert DataSet to List<USR01>

           
            USR01 user = users.FirstOrDefault(u => u.R01F02 == username && u.R01F04 == password);

            return user; 
        }
        #endregion
    }
}
