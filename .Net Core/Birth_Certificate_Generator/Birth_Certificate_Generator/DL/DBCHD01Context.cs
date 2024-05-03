using MySql.Data.MySqlClient;
using System.Data;

namespace Birth_Certificate_Generator.DL
{
    /// <summary>
    /// Handling Child Class Database Operation
    /// </summary>
    public class DBCHD01Context
    {
        #region Private Member
        private readonly string _connectionString;

        #endregion

        #region Constructor
        /// <summary>
        /// To Set instance of Connectionstring
        /// </summary>
        /// <param name="connectionString"></param>
        public DBCHD01Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Get All Children Details
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllChildren()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"
                    SELECT 
                         D01F01 as D01101,
                        D01F02 as D01102,
                        D01F03 as D01103,
                        D01F04 as D01104,
                        D01F05 as D01105,
                        D01F06 as D01106,
                        D01F07 as D01107
                    FROM 
                        CHD01"); 

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
        /// Get Details of Child by its ID
        /// </summary>
       
        /// <returns></returns>
        public DataSet GetChildById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"
                    SELECT 
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
