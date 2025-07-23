using System.Net.Mail;
using System.Net;
using MailMessage = MailSender.Models.MailMessage;
using Microsoft.Extensions.Options;
using MailSender.Configs;


namespace MailSender.Services
{
    public interface IMailsService
    {
        Task SendAsync(MailMessage mailMessage, CancellationToken cancellationToken = default);
    }

    public class MailsService(IOptions<SmtpSettings> options) : IMailsService
    {
        private readonly SmtpSettings _settings = options.Value;


        public async Task SendAsync(MailMessage mailMessage, CancellationToken cancellationToken = default)
        {
            using var client = Create();
            using var message = new System.Net.Mail.MailMessage(mailMessage.SenderEmail, mailMessage.ReceiverEmail, mailMessage.Title, mailMessage.Body);
            await client.SendMailAsync(message, cancellationToken);
        }

        private SmtpClient Create()
        {
            return new(_settings.Host, _settings.Port)
            {
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
            };
        }
    }
}
