using Birth_Certificate_Generator.DL.Interface;
using System.Data;

namespace Birth_Certificate_Generator.DL.Context
{
    /// <summary>
    /// operation with the birth certificate requests in the database.
    /// </summary>
    public class DBBCR01Context : IBCR01Repository
    {
        #region Private Members
        /// <summary>
        /// instance of DBExecContext
        /// </summary>
        private readonly DBExecContext _execContext;

        #endregion

        #region Constructor
        /// <summary>
        /// instance of the DBBCR01Context with the specified connection string.
        /// </summary>
        /// <param name="configuration">The connection string for the database.</param>
        public DBBCR01Context(IConfiguration configuration)
        {
            _execContext = new DBExecContext(configuration);
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all birth certificate request data from the database.
        /// </summary>
        /// <returns>A DataSet containing all birth certificate request data.</returns>
        public DataTable GetAllData()
        {
            string query = string.Format(@"SELECT 
                                                C01F01,
                                                C01F03,
                                                C01F04,
                                                D01F01,
                                                D01F02,
                                                D01F03,
                                                D01F04,
                                                D01F05,
                                                D01F06,
                                                D01F07
                                           FROM 
                                                vws_c01_d01");
            return _execContext.Exec(query);
        }

        /// <summary>
        /// Retrieves all pending birth certificate requests from the database.
        /// </summary>
        /// <returns>A DataSet containing all pending birth certificate requests.</returns>
        public DataTable GetPending()
        {
            string query = string.Format(@"SELECT 
                                                C01F01,
                                                C01F03,
                                                C01F04,
                                                D01F01,
                                                D01F02,
                                                D01F03,
                                                D01F04,
                                                D01F05,
                                                D01F06,
                                                D01F07
                                            FROM 
                                                vws_c01_d01 
                                            WHERE 
                                                C01F04 = 'P'");
            return _execContext.Exec(query);
        }

        /// <summary>
        /// Retrieves birth certificate request data by ID.
        /// </summary>
        /// <param name="id">The ID of the birth certificate request.</param>
        /// <returns>A DataSet containing the birth certificate request data for the specified ID.</returns>
        public DataTable GetDataByID(int id)
        {
            string query = string.Format(@"SELECT 
                                                    C01F01,
                                                    C01F02,
                                                    C01F03,
                                                    C01F04,
                                                    D01F01,
                                                    D01F02,
                                                    D01F03,
                                                    D01F04,
                                                    D01F05,
                                                    D01F06,
                                                    D01F07,
                                                    D01F09
                                                FROM 
                                                    vws_c01_d01 
                                                WHERE 
                                                    C01F01 = {0}", id);
            return _execContext.Exec(query);
        }

        #endregion
    }
}
