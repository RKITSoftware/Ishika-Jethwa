using System.Configuration;

namespace Employee_CRUD.Connections_Strings
{
    public static class Connections
    {
        public static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}