using CM.TeamReport.Domain.Exceptions;
using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Moq;

namespace CM.TeamReports.Domain.Tests
{
    public class TeamServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateTeam()
        {
            var teamsMock = new Mock<IRepository<Teams>>();

            var teamService = new TeamService(teamsMock.Object);

            Assert.True(teamService.Add("Team") is Task);
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

            Assert.True(teamService.Edit(team) is Task);
        }
    }
}
