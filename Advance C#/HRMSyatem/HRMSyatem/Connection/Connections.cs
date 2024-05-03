using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;
using System;
using System.IO;

namespace HRMSystem.Connection
{
    /// <summary>
    /// Class for managing database connections.
    /// </summary>
    public class Connections
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        public static readonly string connection;

        /// <summary>
        /// The OrmLiteConnectionFactory instance for creating database connections.
        /// </summary>
        public static OrmLiteConnectionFactory dbFactory;

        static Connections()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsetting.json");

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(jsonFilePath);

            var configuration = configurationBuilder.Build();
            connection = configuration.GetConnectionString("ConnectionStrings");

            dbFactory = new OrmLiteConnectionFactory(connection, MySqlDialect.Provider);
        }
    }
}
