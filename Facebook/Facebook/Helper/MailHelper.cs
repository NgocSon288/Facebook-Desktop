using Facebook.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Helper
{
    public static class MailHelper
    {
        public static Task SendMail(string toEmailAddress, string subject, string content)
        {
            Task task = new Task(() =>
            {
                string body = content;

                MailAddress fromMailAddress = new MailAddress(Constants.FROM_EMAIL_ADDRESS);
                MailAddress toMailAddress = new MailAddress(toEmailAddress);

                MailMessage message = new MailMessage(fromMailAddress, toMailAddress);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                var client = new SmtpClient();
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(Constants.FROM_EMAIL_ADDRESS, Constants.FROM_EMAIL_PASSWORD);
                client.Host = Constants.SMTP_HOST;
                client.EnableSsl = Constants.ENABLED_SSL;
                client.Port = Constants.SMTP_PORT;
                client.Send(message);
            });

            task.Start();
            return task;
        }
    }
}
