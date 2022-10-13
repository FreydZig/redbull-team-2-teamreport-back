using CM.TeamReport.Domain.Exceptions;
using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Moq;
using FluentAssertions;

namespace CM.TeamReports.Domain.Tests
{
    public class TeamServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            teamsMock.Setup(t => t.CreateWithReturn(It.IsAny<Teams>())).Returns(2);

            var teamService = new TeamService(teamsMock.Object);

            Assert.Equal(2, teamService.Add("sdada"));
        }

        [Fact]
        public void ShouldNotBeAbleToCreateTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            var teamService = new TeamService(teamsMock.Object);

            var exeption = Assert.Throws<TeamExeption>(() => teamService.Add("  "));
            Assert.Equal("Team name is't correct!", exeption.Message);
        }

        [Fact]
        public void ShouldBeAbleToEditTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            var team = new Teams
            {
                TeamId = 1,
                TeamName = "Team"
            };

            var teamService = new TeamService(teamsMock.Object);

            teamService.Invoking(t => t.Edit(team)).Should().NotThrow();
        }

        [Fact]
        public void ShouldNotBeAbleToEditTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            var team = new Teams
            {
                TeamId = 1,
                TeamName = ""
            };

            var teamService = new TeamService(teamsMock.Object);

            var exeption = Assert.Throws<TeamExeption>(() => teamService.Edit(null));
            Assert.Equal("Team is null!", exeption.Message);

            var exeptionWithTeam = Assert.Throws<TeamExeption>(() => teamService.Edit(team));
            Assert.Equal("Team name is't correct!", exeptionWithTeam.Message);
        }

        [Fact]
        public void ShouldBeAbleToReturnTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            var team = new Teams
            {
                TeamId = 1,
                TeamName = "dawdwawada"
            };

            teamsMock.Setup(t => t.Read(It.IsAny<int>())).ReturnsAsync(team);

            var teamService = new TeamService(teamsMock.Object);

            Assert.Equal("dawdwawada", teamService.Get(1).Result.TeamName);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnTeam()
        {
            var teamsMock = new Mock<ITeamRepository>();

            var team = new Teams
            {
                TeamId = 1,
                TeamName = "dawdwawada"
            };

            teamsMock.Setup(t => t.Read(It.IsAny<int>())).ThrowsAsync(new TeamExeption("There is no that company!"));

            var teamService = new TeamService(teamsMock.Object);

            var exeption = Assert.ThrowsAsync<TeamExeption>(() => teamService.Get(1));
            Assert.Equal("There is no that company!", exeption.Result.Message);
        }

    }
}
