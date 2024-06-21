using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;
using System;
using System.IO;


namespace DBCrudFrmaework.Connection
{
    /// <summary>
    /// Provides a centralized access point for the database connection string.
    /// </summary>
    public class Connections
    {
        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        public static readonly string connection;

        /// <summary>
        /// Static constructor to initialize the database connection string from a JSON configuration file.
        /// </summary>
        static Connections()
        {
            // Constructing the path to the JSON configuration file.
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "databaseconfig.json");

            // Building the configuration using ConfigurationBuilder.
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile(jsonFilePath);

            // Building the configuration object.
            var configuration = configurationBuilder.Build();

            // Retrieving the connection string named "ConnectionStrings" from the configuration.
            connection = configuration.GetConnectionString("ConnectionStrings");
            dbFactory = new OrmLiteConnectionFactory(connection, MySqlDialect.Provider);
        }
        public static OrmLiteConnectionFactory dbFactory;
    }
}
