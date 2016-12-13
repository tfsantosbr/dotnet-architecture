using System.Net.Mail;
using Project.Configurations;

namespace Project.Helpers.Email
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            From = new MailAddress(GlobalSettings.EMAIL_DEFAULT_SENDER);
            To = new MailAddressCollection();
            Type = MessageType.Html;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public MessageType Type { get; set; }
        public MailAddress From { get; set; }
        public MailAddressCollection To { get; set; }
    }

    public enum MessageType
    {
        Html,
        Text
    }
}