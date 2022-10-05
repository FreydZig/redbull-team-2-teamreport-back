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
    }
}
