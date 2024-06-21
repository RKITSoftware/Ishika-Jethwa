using Birth_Certificate_Generator.DL.Interface;
using System.Data;

namespace Birth_Certificate_Generator.DL.Context
{
    /// <summary>
    /// Handling Child Class Database Operation
    /// </summary>
    public class DBCHD01Context : ICHD01Repository
    {
        #region Private Members
        /// <summary>
        /// instance of DBExecContext
        /// </summary>
        private readonly DBExecContext _execContext;

        #endregion

        #region Constructor
        /// <summary>
        /// To Set instance of DBExecContext
        /// </summary>
       
        public DBCHD01Context(IConfiguration configuration)
        {
            _execContext = new DBExecContext(configuration);
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Get All Children Details
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllChildren()
        {
                string query = string.Format(@"SELECT 
                                                    D01F01 as D01101,
                                                    D01F02 as D01102,
                                                    D01F03 as D01103,
                                                    D01F04 as D01104,
                                                    D01F05 as D01105,
                                                    D01F06 as D01106,
                                                    D01F07 as D01107
                                                FROM 
                                                    CHD01");

                return _execContext.Exec(query);
        }

        /// <summary>
        /// Get Details of Child by its ID
        /// </summary>
        /// <returns></returns>
        public DataTable GetChildById(int id)
        {
                string query = string.Format(@"SELECT 
                                                    D01F01 as D01101,
                                                    D01F02 as D01102,
                                                    D01F03 as D01103,
                                                    D01F04 as D01104,
                                                    D01F05 as D01105,
                                                    D01F06 as D01106,
                                                    D01F07 as D01107
                                                FROM 
                                                    CHD01
                                                WHERE 
                                                    D01F01 = {0}", id);

            return _execContext.Exec(query);
        }

        #endregion
    }
}
