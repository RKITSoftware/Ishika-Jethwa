using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Birth_Certificate_Generator.Connection
{
    /// <summary>
    /// Provides an ORM Lite context for establishing database connections.
    /// </summary>
    public class OrmLiteContext : IOrmLiteContext
    {
        /// <summary>
        /// The database connection factory used to create connections.
        /// </summary>
        public IDbConnectionFactory DbFactory { get; }

        /// <summary>
        /// instance of the OrmLiteContext with a specified connection string.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public OrmLiteContext(string connectionString)
        {
            DbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider); // Sets up the ORM Lite connection factory
        }
    }
}
