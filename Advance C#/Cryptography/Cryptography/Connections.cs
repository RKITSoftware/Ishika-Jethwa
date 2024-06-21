using System.Configuration;

namespace Cryptography
{
    public static class Connections
    {
        public static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}