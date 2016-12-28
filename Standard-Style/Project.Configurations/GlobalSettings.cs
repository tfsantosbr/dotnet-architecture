using System;
using System.Configuration;

namespace Project.Configurations
{
    public static class GlobalSettings
    {
        public static string APPLICATION_NAME => ConfigurationManager.AppSettings["APPLICATION_NAME"];
        public static string DATABASE => ConfigurationManager.AppSettings["DATABASE"];

        public static double TOKEN_EXPIRATION_TIMEOUT
            => Convert.ToDouble(ConfigurationManager.AppSettings["TOKEN_EXPIRATION_TIMEOUT"]);

        public static string EMAIL_CREDENTIALS_USERNAME
            => ConfigurationManager.AppSettings["EMAIL_CREDENTIALS_USERNAME"];

        public static string EMAIL_CREDENTIALS_PASSWORD
            => ConfigurationManager.AppSettings["EMAIL_CREDENTIALS_PASSWORD"];

        public static string EMAIL_SMTP_HOST_ADDRESS => ConfigurationManager.AppSettings["EMAIL_SMTP_HOST_ADDRESS"];
        public static string EMAIL_DEFAULT_SENDER => ConfigurationManager.AppSettings["EMAIL_DEFAULT_SENDER"];
        public static short EMAIL_SMTP_PORT => Convert.ToInt16(ConfigurationManager.AppSettings["EMAIL_SMTP_PORT"]);

        public static bool EMAIL_SMTP_ENABLE_SSL
            => Convert.ToBoolean(ConfigurationManager.AppSettings["EMAIL_SMTP_ENABLE_SSL"]);
    }

    public static class DatabaseType
    {
        public static string SqlServer => "SqlServer";
        public static string Mongo => "Mongo";
    }
}