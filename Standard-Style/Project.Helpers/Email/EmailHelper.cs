using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Project.Configurations;

namespace Project.Helpers.Email
{
    public class EmailHelper
    {
        #region - MAIN METHODS -

        public async Task SendAsync(EmailMessage message)
        {
            if (NetworkCredentials == null)
                throw new ArgumentNullException(nameof(NetworkCredentials));

            if (SmtpClient == null)
                throw new ArgumentNullException(nameof(SmtpClient));

            var mailMessage = new MailMessage();
            mailMessage.From = message.From;

            foreach (var addressRecipient in message.To)
                mailMessage.To.Add(addressRecipient);

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = message.Type == MessageType.Html;

            await SmtpClient.SendMailAsync(mailMessage);
        }

        #endregion

        #region - PROPERTIES -

        public NetworkCredential NetworkCredentials { get; set; }
        public SmtpClient SmtpClient { get; set; }

        #endregion

        #region - CONSTRUCTORS -

        public EmailHelper()
        {
            NetworkCredentials = new NetworkCredential(GlobalSettings.EMAIL_CREDENTIALS_USERNAME,
                GlobalSettings.EMAIL_CREDENTIALS_PASSWORD);

            SmtpClient = new SmtpClient(GlobalSettings.EMAIL_SMTP_HOST_ADDRESS);
            SmtpClient.Port = GlobalSettings.EMAIL_SMTP_PORT;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.EnableSsl = GlobalSettings.EMAIL_SMTP_ENABLE_SSL;
            SmtpClient.Credentials = NetworkCredentials;
        }

        public EmailHelper(NetworkCredential netwrokCredentials, SmtpClient smtpClient)
        {
            NetworkCredentials = netwrokCredentials;
            SmtpClient = smtpClient;
        }

        #endregion
    }
}