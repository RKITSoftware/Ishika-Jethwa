using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FileJsonDemo
{
    public class connections
    {
        public static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// Gets the OrmLiteConnectionFactory instance for connecting to the database.
        /// </summary>
        public static OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory
               (connection, MySqlDialect.Provider);
    }
}