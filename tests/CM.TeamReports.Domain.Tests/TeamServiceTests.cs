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
            var teamsMock = new Mock<IRepository<Teams>>();

            var teamService = new TeamService(teamsMock.Object);

            teamService.Invoking(t => t.Add("dawd")).Should().NotThrow();
        }

        [Fact]
        public void ShouldNotBeAbleToCreateTeam()
        {
            var teamsMock = new Mock<IRepository<Teams>>();

            var teamService = new TeamService(teamsMock.Object);

            var exeption = Assert.Throws<TeamExeption>(() => teamService.Add("  "));
            Assert.Equal("Team name is't correct!", exeption.Message);
        }

        [Fact]
        public void ShouldBeAbleToEditTeam()
        {
            var teamsMock = new Mock<IRepository<Teams>>();

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
            var teamsMock = new Mock<IRepository<Teams>>();

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

    }
}
