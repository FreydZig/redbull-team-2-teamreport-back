using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Moq;

namespace CM.TeamReports.Domain.Tests
{
    public class LeaderServiceTests
    {

        [Fact]
        public void ShouldBeAbleToCreateLeaderService()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            Assert.NotNull(leader);
        }

        
        [Fact]
        public void ShouldBeAbleToReturnOverallReports()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users>()
            {
                new Users()
            });

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.OverallReports(1);

            Assert.Equal(1 ,list.Count);
        }


        [Fact]
        public void ShouldBeAbleToReturnPreviousReports()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users>()
            {
                new Users()
            });

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.PreviousReports(1);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnPreviousReports()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users>()
            {
                new Users()
            });

            reportsMock.Setup(r => r.ReadByUserId(It.IsAny<int>())).Returns(new Reports());

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.PreviousReports(1);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnTrueFromIsLeader()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

          leaderMock.Setup(l => l.Read(It.IsAny<int>())).Returns(new Leaders { 
          
              UserId = 28,
              TeamId = 1,
              LeaderId = 9

          });

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            Assert.True(leader.IsLeader(28));
        }

        [Fact]
        public void ShouldNotBeAbleToReturnTrueFromIsLeader()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            leaderMock.Setup(l => l.Read(It.IsAny<int>())).Returns((Leaders)null);

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            Assert.False(leader.IsLeader(21));
        }
    }
}
