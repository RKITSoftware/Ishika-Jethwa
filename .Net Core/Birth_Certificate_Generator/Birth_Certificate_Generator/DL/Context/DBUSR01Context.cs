using Birth_Certificate_Generator.DL.Interface;
using System.Data;

namespace Birth_Certificate_Generator.DL.Context
{
    /// <summary>
    /// interacting with the USR01 table in the database.
    /// </summary>
    public class DBUSR01Context : IUSR01Repository
    {
        #region Private Members
        /// <summary>
        /// instance of DBExecContext
        /// </summary>
        private readonly DBExecContext _execContext;

        #endregion

        #region Constructor
        /// <summary>
        /// instance of the DBUSR01Context with the specified connection string.
        /// </summary>
        /// <param name="configuration">The connection string for the database.</param>
        public DBUSR01Context(IConfiguration configuration)
        {
            _execContext = new DBExecContext(configuration);
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all user records from the USR01 table in the database.
        /// </summary>
        /// <returns>A DataSet containing all user records.</returns>
        public DataTable GetAllUser()
        {

            string query = string.Format(@"SELECT 
                                         R01F01 as R01101,
                                         R01F02 as R01102,
                                         R01F03 as R01103,
                                         CASE WHEN R01F05 = 'A' THEN 'Admin'
                                              WHEN R01F05 = 'U' THEN 'User'
                                         END AS R01F05 
                                 FROM 
                                         USR01");

            return _execContext.Exec(query);
        }

        /// <summary>
        /// Retrieves user records by their username from the USR01 table.
        /// </summary>
        /// <param name="username">The username to search </param>
        /// <returns>A DataSet containing the user record with the specified username.</returns>
        public DataTable GetUserByUserName(string username)
        {
            string query = string.Format(@"SELECT 
                                                R01F02 as R01102,
                                                R01F03 as R01103,
                                                CASE WHEN R01F05 = 'A' THEN 'Admin'
                                                     WHEN R01F05 = 'U' THEN 'User'
                                                END AS R01F05 
                                          FROM 
                                                USR01
                                          WHERE 
                                                R01F02 = '{0}'", username);

            return _execContext.Exec(query);
        }

        #endregion
    }
}
