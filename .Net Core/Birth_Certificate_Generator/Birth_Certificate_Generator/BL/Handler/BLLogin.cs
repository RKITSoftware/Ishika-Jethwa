using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.POCO;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Data;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Handler class for managing login and user validation.
    /// </summary>
    public class BLLogin
    {
        #region Private Member
        /// <summary>
        /// Configuration string for database operations.
        /// </summary>
        private readonly string _configuration;

        /// <summary>
        /// instance of OrmLite Connection Factopry
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;
        #endregion

        #region Constructor

        /// <summary>
        /// instance of the BLLogin class, setting up the configuration and database connection string.
        /// </summary>
        public BLLogin()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            _configuration = configuration.GetConnectionString("Default");
            _dbFactory = new OrmLiteConnectionFactory(_configuration,MySqlDialect.Provider);
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A DataSet containing all user records.</returns>
        public List<USR01> GetUser()
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return  db.Select<USR01>();
            }
        }

        /// <summary>
        /// Validates a user based on the provided username and password.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password associated with the username.</param>
        /// <returns>The validated user or null if the user is invalid.</returns>
        public USR01 ValidateUser(Login objLogin)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                // Directly query the database for the user
                USR01 user = db.Single<USR01>(u => u.R01F02 == objLogin.L01F01 && u.R01F04 == objLogin.L01F02);
                return user;
            }
        }

        /// <summary>
        /// Validate a User based on username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public USR01 ValidateUserName(string username)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                // Directly query the database for the user by username
                USR01 user = db.Single<USR01>(u => u.R01F02 == username);
                return user;
            }
        }
        #endregion
    }
}
