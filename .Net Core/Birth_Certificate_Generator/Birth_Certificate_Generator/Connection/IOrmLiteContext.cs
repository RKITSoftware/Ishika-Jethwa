using ServiceStack.Data;

namespace Birth_Certificate_Generator.Connection
{
    public interface IOrmLiteContext
    {
        IDbConnectionFactory DbFactory { get; }
    }
}