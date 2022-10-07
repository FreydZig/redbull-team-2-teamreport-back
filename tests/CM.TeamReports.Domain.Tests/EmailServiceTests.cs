using CM.TeamReport.Domain.Services;
using CM.TeamReport.Domain.Services.Interfaces;
using FluentAssertions;
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
            var emailService = new EmailService();
            emailService.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToSendEmail()
        {
            
        }
    }
}
