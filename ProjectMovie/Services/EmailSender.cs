using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;

namespace ProjectMovie.Services
{
    public class EmailSender : IEmailSender
    {
        const string Mail = "projectmoviewebapp@gmail.com";
        const string Password = "noea bzby mbzs chny";
        const string Host = "smtp.gmail.com";
        const int Port = 587;

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(Mail, "ProjectMovie"),
                To = { email },
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            SmtpClient client = new(Host, Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Mail, Password)
            };

            return client.SendMailAsync(message);
        }
    }
}
