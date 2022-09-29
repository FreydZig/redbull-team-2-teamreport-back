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

            var list = team.GetAll(1);

            Assert.NotNull(team);
            Assert.Equal(1, list.Count);

        }
    }
}