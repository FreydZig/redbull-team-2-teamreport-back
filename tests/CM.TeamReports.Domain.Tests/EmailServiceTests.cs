
using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services;
using CM.TeamReport.Domain.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReports.Domain.Tests
{
    public class EmailServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEmailService()
        {
            var configurationMock = new Mock<IConfiguration>();
            var emailService = new EmailService(configurationMock.Object);
            emailService.Should().NotBeNull();
        }

/*        [Fact]
        public void ShouldBeAbleToSendEmail()
        {
            var configurationMock = new Mock<IConfiguration>();
            var emailService = new EmailService(configurationMock.Object);
            InviteMember member = new InviteMember()
            {
                Email = "timoschenko.ivan5@gmai.com",
                FirstName = "Ivan",
                LastName = "Timoschenko",
                Link = "youtube.com"
            };
            emailService.SendEmail(member);
            
        }*/
    }
}
