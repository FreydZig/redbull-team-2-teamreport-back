using CM.TeamReport.Domain.Models;
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

            Assert.Single(list);
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

            Assert.Single(list);
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

            reportsMock.Setup(r => r.ReadByUserIdAndPeriod(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new Reports());

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.PreviousReports(1);

            Assert.Single(list);
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

        [Fact]
        public void ShouldBeAbleToReturnStateSort()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            var user = new Users
            {
                FirstName = "Tom",
                LastName = "Andelson",
                Email = "email@mail.com",
                Password = "dadwd",
                TeamId = 1,
                Title = "dwwad"
            };

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users> { user });

            reportsMock.Setup(r => r.UserState(It.IsAny<int>(), It.IsAny<char>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(1);

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.StateSort(1, 'd');

            Assert.Single(list);
            Assert.Equal(1, list[0].Current);
            Assert.Equal("Tom Andelson", list[0].UserName);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnStateSort()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            var user = new Users
            {
                FirstName = "Tom",
                LastName = "Andelson",
                Email = "email@mail.com",
                Password = "dadwd",
                TeamId = 1,
                Title = "dwwad"
            };

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns((List<Users>)null);

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.StateSort(1, 'd');

            Assert.Equal(new List<OverallReports>(),list);
        }

        [Fact]
        public void ShouldBeAbleToReturnListOfCurrentReports()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();

            var user = new Users
            {
                FirstName = "Tom",
                LastName = "Andelson",
                Email = "email@mail.com",
                Password = "dadwd",
                TeamId = 1,
                Title = "dwwad"
            };

            var report = new Reports
            {
                UserId = 1,
                Morale = 3,
                MoraleDescription = "fafwaf",
                Stress = 2,
                StressDescription = "dwadawdwa",
                Workload = 5,
                WorkloadDescription = "wewqqeqwd",
                High = "dawdaxsc",
                Low = "lmpmpompiom",
                DateRange = new DateTime(),
                AnythingElse = "wddw"
            };

            usersMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users> { user });

            reportsMock.Setup(r => r.ReadByUserIdAndPeriod(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(report);

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            var list = leader.CurentReports(1);

            Assert.Single(list);
            Assert.Equal("Tom Andelson", list[0].Name);
        }
    }
}
