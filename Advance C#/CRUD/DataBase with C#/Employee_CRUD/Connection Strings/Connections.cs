using System.Configuration;

namespace Employee_CRUD.Connections_Strings
{
    /// <summary>
    /// Class to manage database connection strings.
    /// </summary>
    public static class Connections
    {
        /// <summary>
        /// Gets the database connection string from the application configuration file.
        /// </summary>
        public static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
