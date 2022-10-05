using CM.TeamReport.Domain.Services;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReports.Domain.Tests
{
    public class LeaderServiceTests
    {

        [Fact]
        public void ShouldBeAbleToCreateLeaderService()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<IRepository<Leaders>>();

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            Assert.NotNull(leader);
        }

        //[Fact]
        //public void ShouldBeAbleToInviteToTeam()
        //{
        //    var reportsMock = new Mock<IReportsRepository>();
        //    var usersMock = new Mock<IUserRepository>();

        //    usersMock.Setup(u => u.Update(It.IsAny<Users>()));

        //    LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object);

        //    var user = new Users
        //    {
        //        UserId = 31,
        //        FirstName = "First NAme",
        //        LastName = "LastName",
        //        Email = "second@example.com",
        //        Password = "dwadawdwadawd"
        //    };

        //    leader.InviteTeam("second@example.com", 1);

        //}
        
        [Fact]
        public void ShouldBeAbleToReturnOverallReports()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var usersMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<IRepository<Leaders>>();

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
            var leaderMock = new Mock<IRepository<Leaders>>();

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
            var leaderMock = new Mock<IRepository<Leaders>>();

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
            var leaderMock = new Mock<IRepository<Leaders>>();

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
            var leaderMock = new Mock<IRepository<Leaders>>();

            leaderMock.Setup(l => l.Read(It.IsAny<int>())).Returns((Leaders)null);

            LeaderService leader = new LeaderService(usersMock.Object, reportsMock.Object, leaderMock.Object);

            Assert.False(leader.IsLeader(21));
        }
    }
}
