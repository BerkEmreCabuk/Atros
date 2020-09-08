using Atros.Common.Models;
using Atros.Common.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace Atros.Common.Services
{
    public class MailService : IMailService
    {
        private readonly IOptions<EmailSettingsModel> _options;
        public MailService(
            IOptions<EmailSettingsModel> options)
        {
            _options = options;
        }

        public async Task SendMail(string toEmail, string subject)
        {
            _options.Value.CheckModel();
            // create email message
            var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_options.Value.SenderEmail);
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = "Film Önerisi";
                email.Body = new TextPart(TextFormat.Plain) { Text = subject };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(_options.Value.Host, _options.Value.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_options.Value.UserName, _options.Value.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
        }
    }
}
