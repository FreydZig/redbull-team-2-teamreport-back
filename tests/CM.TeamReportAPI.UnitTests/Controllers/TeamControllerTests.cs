using CM.TeamReport.Domain.Exceptions;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamRepots.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class TeamControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateTeam()
        {
            var teamMock = new Mock<ITeamService>();

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.CreateCompany("dasdsada");

            Assert.True(answer is OkResult);
        }

        [Fact]
        public void ShouldNotBeAbleToCreateTeam()
        {
            var teamMock = new Mock<ITeamService>();

            teamMock.Setup(t => t.Add(It.IsAny<string>())).Throws(new TeamExeption("Team name is't correct!"));

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.CreateCompany("dasdsada");

            Assert.True(answer is BadRequestObjectResult);
        }

        [Fact]
        public void ShouldBeAbleToEditTeam()
        {
            var teamMock = new Mock<ITeamService>();

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.EditCompany(new Teams());

            Assert.True(answer is OkResult);
        }

        [Fact]
        public void ShouldNotBeAbleToEditTeam()
        {
            var teamMock = new Mock<ITeamService>();

            teamMock.Setup(t => t.Edit(It.IsAny<Teams>())).Throws(new TeamExeption("Team name is't correct!"));

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.EditCompany(new Teams());

            Assert.True(answer is BadRequestObjectResult);
        }
    }
}
