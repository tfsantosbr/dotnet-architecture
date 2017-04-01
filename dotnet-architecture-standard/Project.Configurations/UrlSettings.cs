using System.Configuration;

namespace Project.Configurations
{
    public class UrlSettings
    {
        #region - ACCOUNT -

        public static string URL_ACCOUNT_CONFIRMATION => ConfigurationManager.AppSettings["URL_ACCOUNT_CONFIRMATION"];

        public static string URL_ACCOUNT_RESET_PASSWORD
            => ConfigurationManager.AppSettings["URL_ACCOUNT_RESET_PASSWORD"];

        public static string URL_ACCOUNT_SET_EMAIL => ConfigurationManager.AppSettings["URL_ACCOUNT_SET_EMAIL"];

        #endregion
    }
}