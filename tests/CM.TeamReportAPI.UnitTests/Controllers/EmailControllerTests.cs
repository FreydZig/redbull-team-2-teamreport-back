using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReports.Domain.Tests
{
    public class EmailControllerTests
    {
        [Fact]
        public void SouldBeAbleToCreateController()
        {
            var serviceMock = new Mock<IEmailService>();
            var mapperMock = new Mock<IMapper>();
            EmailController emailController = new EmailController(serviceMock.Object,mapperMock.Object);
            InviteMemberModel inviteMemberModel = new InviteMemberModel()
            {
                Email = "example@gmail.com",
                FirstName = "Test",
                LastName = "Test",
                Link = "lint.test"
            };
            emailController.SendEmail(inviteMemberModel);
            serviceMock.VerifyAll();

        }
    }
}
