using ServiceStack.OrmLite;
using System.IO;
using Microsoft.Extensions.Configuration;
using System;

namespace FinalDemo.Connection
{
    /// <summary>
    /// Provides a centralized location for managing database connections using ServiceStack.OrmLite.
    /// </summary>
    public  class Connections
    {
        public static readonly string connection;

      
        static Connections()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "databaseconfig.json");

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(jsonFilePath);


            var configuration = configurationBuilder.Build();
            connection = configuration.GetConnectionString("ConnectionStrings");

            dbFactory = new OrmLiteConnectionFactory(connection, MySqlDialect.Provider);
        }
        public static OrmLiteConnectionFactory dbFactory;

    }
}
