using System.Configuration;

namespace Project.Configurations
{
    /// <summary>
    ///     CONNECTION STRINGS CONFIG CLASS
    /// </summary>
    public static class ConnectionStrings
    {
        public static string ResourceConnection
            => ConfigurationManager.ConnectionStrings["ResourceConnection"].ConnectionString;

        public static string AuthenticationConnection
            => ConfigurationManager.ConnectionStrings["AuthenticationCOnnection"].ConnectionString;
    }
}