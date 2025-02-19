using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;

namespace ProjectMovie.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            const string Mail = "ProjectMovieWebApp@outlook.com";
            const string Password = "zuoeggdwwegiosgv";
            const string Host = "smtp.office365.com";
            const int Port = 587;

            SmtpClient client = new(Host, Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Mail, Password)
            };

            return client.SendMailAsync(
                new MailMessage(from: Mail,
                                to: email,
                                subject: subject,
                                body: htmlMessage));
        }
    }
}
