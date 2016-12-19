using System.Configuration;

namespace Project.Configurations
{
    /// <summary>
    ///     CONNECTION STRINGS CONFIG CLASS
    /// </summary>
    public static class ConnectionStrings
    {
        public static string SQLServerConnection
            => ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;

        public static string MongoConnection
            => ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
    }
}