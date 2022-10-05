using CM.TeamReport.Domain.Services.Interfaces;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using CM.TeamReport.Domain.Models;

namespace CM.TeamReport.Domain.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailModel request)
        {
            var myemail = new MimeMessage();
            myemail.From.Add(MailboxAddress.Parse("roy.schuster42@ethereal.email"));
            myemail.To.Add(MailboxAddress.Parse(request.To));
            myemail.Subject = request.Subject;
            myemail.Body = new TextPart(TextFormat.Html) { Text = request.Body};

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("roy.schuster42@ethereal.email", "WzJcsyAWrERnjZBdMX");
            smtp.Send(myemail);
            smtp.Disconnect(true);

        }
    }
}
