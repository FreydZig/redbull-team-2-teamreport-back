using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;

namespace CM.TeamReports.Domain.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserService()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<IRepository<Teams>>();
            UserService userService = new UserService(repositoryMock.Object, leaderMock.Object, teamMock.Object);
            userService.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToAddUser()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<IRepository<Teams>>();
            repositoryMock.Setup(r => r.Create(It.IsAny<Users>()));
            UserService userService = new UserService(repositoryMock.Object, leaderMock.Object, teamMock.Object);
            var user = new Users() 
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };
            userService.AddUser(user);
            repositoryMock.Verify(r => r.Create(user));
        }

        [Fact]
        public void ShouldBeAbleToTrueFromChoseLeader()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<IRepository<Teams>>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            var team = new Teams
            {
                TeamName = "Team"
            };

            userMock.Setup(u => u.Read(It.IsAny<int>())).Returns(user);
            teamMock.Setup(t => t.Read(It.IsAny<int>())).Returns(team);

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object);

            Assert.True(userService.ChoseLeader(1,1));
        }

        [Fact]
        public void ShouldBeAbleToFalseFromChoseLeader()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<IRepository<Teams>>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            var team = new Teams
            {
                TeamName = "Team"
            };

            userMock.Setup(u => u.Read(It.IsAny<int>())).Returns((Users)null);
            teamMock.Setup(t => t.Read(It.IsAny<int>())).Returns((Teams)null);

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object);

            Assert.False(userService.ChoseLeader(1, 1));
        }

        [Fact]
        public void ShouldBeAbleToReturnListUsers()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<IRepository<Teams>>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            userMock.Setup(u => u.GetAll(It.IsAny<int>())).Returns(new List<Users> { user });

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object);

            var users = userService.ListUsers(1);

            Assert.Single(users);
        }
    }
}
