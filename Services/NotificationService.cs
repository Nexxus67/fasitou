using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;


namespace fasito.Services
{
    public interface INotificationService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }

    public class EmailNotificationService : INotificationService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _fromPassword;

        public EmailNotificationService(string smtpServer, int smtpPort, string fromEmail, string fromPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _fromEmail = fromEmail;
            _fromPassword = fromPassword;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_fromEmail, _fromPassword),
                EnableSsl = true,
            };

            var message = new MailMessage(_fromEmail, to)
            {
                Subject = subject,
                Body = body,
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
