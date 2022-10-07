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
using Microsoft.Extensions.Configuration;

namespace CM.TeamReport.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(InviteMember request)
        {
            var myemail = new MimeMessage();
            myemail.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailConfig:EmailUsername").Value));
            myemail.To.Add(MailboxAddress.Parse(request.Email));
            myemail.Subject = "Team Invitation ";
            myemail.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Hello {request.FirstName} you were invited to the team.</h1><p>Follow this lonk to join us: <a href=\"{request.Link}\"></a>" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailConfig:EmailHost").Value,int.Parse(_configuration.GetSection("EmailConfig:EmailPort").Value), SecureSocketOptions.Auto);
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");
            smtp.Authenticate(_configuration.GetSection("EmailConfig:EmailUsername").Value, _configuration.GetSection("EmailConfig:EmailPassword").Value);
            smtp.Send(myemail);
            smtp.Disconnect(true);

        }
    }
}
