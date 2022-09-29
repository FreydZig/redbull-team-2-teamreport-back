using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Repositories;
using Xunit;

namespace CM.TeamReports.DataLayer.tests
{
    public class TeamRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToReturnListOfTeams()
        {
            TeamsRepository team = new TeamsRepository();

            var teams = team.GetAll();

            Assert.NotNull(team);
            Assert.Equal(8, teams.Count);

        }

        [Fact]
        public void ShouldBeAbleToReturnTeam()
        {
            TeamsRepository team = new TeamsRepository();

            var team1 = team.Read(1);

            Assert.Equal(1, team1.TeamId);

        }

        [Fact]
        public void ShouldBeAbleToCreateTeam()
        {
            TeamsRepository team = new TeamsRepository();

            team.Create(new Teams{ TeamName = "Team" });

            Assert.Equal("Team", team.Read(7).TeamName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateTeam()
        {
            TeamsRepository team = new TeamsRepository();

            team.Update(new Teams { TeamId = 7, TeamName = "NoName" });

            Assert.Equal("NoName", team.Read(7).TeamName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteTeam()
        {
            TeamsRepository team = new TeamsRepository();

            team.Delete(7);

            Assert.Null(team.Read(7));
        }
    }
}