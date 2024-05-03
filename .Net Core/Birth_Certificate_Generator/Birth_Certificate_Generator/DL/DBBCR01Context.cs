using MySql.Data.MySqlClient;
using System.Data;

namespace Birth_Certificate_Generator.DL
{
    /// <summary>
    /// Data layer context for interacting with the birth certificate requests in the database.
    /// </summary>
    public class DBBCR01Context
    {
        #region Private Members
        /// <summary>
        /// The database connection string used for MySql operations.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the DBBCR01Context with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public DBBCR01Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all birth certificate request data from the database.
        /// </summary>
        /// <returns>A DataSet containing all birth certificate request data.</returns>
        public DataSet GetAllData()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT 
                                        C01F01,
                                        C01F03,
                                        CASE 
                                            WHEN C01F04 = 'P' THEN 'Pending' 
                                            WHEN C01F04 = 'A' THEN 'Approved' 
                                            WHEN C01F04 = 'R' THEN 'Rejected'
                                            ELSE 'Unknown' 
                                        END AS Status,
                                        D01F01,
                                        D01F02,
                                        D01F03,
                                        D01F04,
                                        D01F05,
                                        CASE 
                                            WHEN D01F06 = 'M' THEN 'Male' 
                                            WHEN D01F06 = 'F' THEN 'Female' 
                                            ELSE 'Other' 
                                        END AS D01F06,
                                        D01F07
                                    FROM 
                                        vws_c01_d01";

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
        /// Retrieves all pending birth certificate requests from the database.
        /// </summary>
        /// <returns>A DataSet containing all pending birth certificate requests.</returns>
        public DataSet GetPending()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT 
                                        C01F01,
                                        C01F03,
                                        CASE 
                                            WHEN C01F04 = 'P' THEN 'Pending' 
                                            WHEN C01F04 = 'A' THEN 'Approved' 
                                            WHEN C01F04 = 'R' THEN 'Rejected'
                                            ELSE 'Unknown' 
                                        END AS Status,
                                        D01F01,
                                        D01F02,
                                        D01F03,
                                        D01F04,
                                        D01F05,
                                        CASE 
                                            WHEN D01F06 = 'M' THEN 'Male' 
                                            WHEN D01F06 = 'F' THEN 'Female' 
                                            ELSE 'Other' 
                                        END AS Gender,
                                        D01F07
                                    FROM 
                                        vws_c01_d01 
                                    WHERE 
                                        C01F04 = 'P'"; 

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
        /// Retrieves birth certificate request data by ID.
        /// </summary>
        /// <param name="id">The ID of the birth certificate request.</param>
        /// <returns>A DataSet containing the birth certificate request data for the specified ID.</returns>
        public DataSet GetDataByID(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"SELECT 
                                                    C01F01,
                                                    C01F03,
                                                    CASE 
                                                        WHEN C01F04 = 'P' THEN 'Pending' 
                                                        WHEN C01F04 = 'A' THEN 'Approved' 
                                                        WHEN C01F04 = 'R' THEN 'Rejected'
                                                        ELSE 'Unknown' 
                                                    END AS Status,
                                                    D01F01,
                                                    D01F02,
                                                    D01F03,
                                                    D01F04,
                                                    D01F05,
                                                    CASE 
                                                        WHEN D01F06 = 'M' THEN 'Male' 
                                                        WHEN D01F06 = 'F' THEN 'Female' 
                                                        ELSE 'Other' 
                                                    END AS Gender,
                                                    D01F07
                                                FROM 
                                                    vws_c01_d01 
                                                WHERE 
                                                    C01F01 = {0}", id); 

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
