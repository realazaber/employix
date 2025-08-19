using Employix.Domain.Models.Entities;
using Employix.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace Employix.Infrastructure.Services
{
    public class MailSender : IEmailSender<User>
    {
        private readonly SmtpClient client;
        private readonly string sender;

        public MailSender(IOptions<EmailSettings> options)
        {
            var settings = options.Value;
            sender = settings.Sender;

            client = new SmtpClient
            {
                Host = settings.Provider,
                Port = settings.Port,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(settings.Sender, settings.Password)
            };
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(sender),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mail.To.Add(email);
            return client.SendMailAsync(mail);
        }

        public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {

            var mail = new MailMessage
            {
                From = new MailAddress(sender),
                Subject = "Confirm your email",
                Body = $"Please confirm your email by clicking on the following link: <a href='{confirmationLink}'>Confirm Email</a>",
                IsBodyHtml = true
            };
            mail.To.Add(email);
            return client.SendMailAsync(mail);
        }

        public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
        {
            return SendEmailAsync(email, "Reset your password",
                $"Please reset your password using the following code: {resetCode}");
        }

        public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            return SendEmailAsync(email, "Reset your password",
                $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
        }
    }

}
