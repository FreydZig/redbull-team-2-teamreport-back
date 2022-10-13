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

            teamMock.Setup(t => t.Add(It.IsAny<string>())).ReturnsAsync(true);

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.CreateCompany("dasdsada");

            Assert.True(answer.Result is OkResult);
        }

        [Fact]
        public void ShouldNotBeAbleToCreateTeam()
        {
            var teamMock = new Mock<ITeamService>();

            teamMock.Setup(t => t.Add(It.IsAny<string>())).ReturnsAsync(false);

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.CreateCompany("dasdsada");

            Assert.True(answer.Result is BadRequestObjectResult);
        }

        [Fact]
        public void ShouldBeAbleToEditTeam()
        {
            var teamMock = new Mock<ITeamService>();

            teamMock.Setup(t => t.Edit(It.IsAny<Teams>())).ReturnsAsync(true);

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.EditCompany(new Teams());

            Assert.True(answer.Result is OkResult);
        }

        [Fact]
        public void ShouldNotBeAbleToEditTeam()
        {
            var teamMock = new Mock<ITeamService>();

            teamMock.Setup(t => t.Edit(It.IsAny<Teams>())).ReturnsAsync(false);

            var teamController = new TeamController(teamMock.Object);

            var answer = teamController.EditCompany(new Teams());

            Assert.True(answer.Result is BadRequestObjectResult);
        }
    }
}
