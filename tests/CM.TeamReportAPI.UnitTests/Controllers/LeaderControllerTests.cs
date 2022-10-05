using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using Moq;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class LeaderControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateLearderController()
        {
            var leaderService = new Mock<ILeaderSevice>();

            LeaderController leaderController = new LeaderController(leaderService.Object);

            Assert.NotNull(leaderController);
        }

        [Fact]
        public void ShouldBeAbleToReturnOlderReports()
        {
            var leaderService = new Mock<ILeaderSevice>();

            leaderService.Setup(l => l.OverallReports(It.IsAny<int>())).Returns(new List<TeamReport.Domain.Models.OverallReports>() { new TeamReport.Domain.Models.OverallReports() });

            LeaderController leaderController = new LeaderController(leaderService.Object);

            Assert.Equal(1, leaderController.OlderReports(1).Count());
        }

        [Fact]
        public void ShouldBeAbleToReturnPreviousReports()
        {
            var leaderService = new Mock<ILeaderSevice>();

            leaderService.Setup(l => l.PreviousReports(It.IsAny<int>())).Returns(new List<TeamReport.Domain.Models.PreviousReports> { new TeamReport.Domain.Models.PreviousReports() });

            LeaderController leaderController = new LeaderController(leaderService.Object);

            Assert.Equal(1, leaderController.PreviousPeriod(1).Count());
        }

        [Fact]
        public void ShouldBeAbleToReturnTrueFromCheck()
        {
            var leaderService = new Mock<ILeaderSevice>();

            leaderService.Setup(l => l.IsLeader(It.IsAny<int>())).Returns(true);
            LeaderController leaderController = new LeaderController(leaderService.Object);

            Assert.True(leaderController.Check(1));
        }
    }
}
