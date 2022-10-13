using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;
using System.Data;

namespace CM.TeamReports.Domain.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserService()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var reportsMock = new Mock<IReportsRepository>();
            UserService userService = new UserService(repositoryMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);
            userService.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToAddUser()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var reportsMock = new Mock<IReportsRepository>();
            repositoryMock.Setup(r => r.Create(It.IsAny<Users>()));
            UserService userService = new UserService(repositoryMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);
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
            var teamMock = new Mock<ITeamRepository>();
            var reportsMock = new Mock<IReportsRepository>();

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

            userMock.Setup(u => u.Read(It.IsAny<int>())).ReturnsAsync(user);
            teamMock.Setup(t => t.Read(It.IsAny<int>())).ReturnsAsync(team);

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);

            Assert.True(userService.ChoseLeader(1,1).Result);
        }

        [Fact]
        public void ShouldBeAbleToFalseFromChoseLeader()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var reportsMock = new Mock<IReportsRepository>();

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

            userMock.Setup(u => u.Read(It.IsAny<int>())).ReturnsAsync((Users)null);
            teamMock.Setup(t => t.Read(It.IsAny<int>())).ReturnsAsync((Teams)null);

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);

            Assert.False(userService.ChoseLeader(1, 1).Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnListUsers()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var reportsMock = new Mock<IReportsRepository>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            userMock.Setup(u => u.GetAll(It.IsAny<int>())).ReturnsAsync(new List<Users> { user });

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);

            var users = userService.ListUsers(1);

            Assert.Single(users.Result);
        }

        [Fact]
        public void ShouldBeAbleToEditUserInformation()
        {
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();

            var reportsMock = new Mock<IReportsRepository>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            var editUser = new Users()
            {
                FirstName = "Chenged Name",
                LastName = "Chenged Last Name",
                Email = "ChengedUser@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            userMock.Setup(u => u.Read(It.IsAny<int>())).ReturnsAsync(user);

            userMock.Setup(u => u.Update(It.IsAny<Users>()));

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);

            var result = userService.EditUserInformation(editUser);

            userMock.Verify(x => x.Update(It.IsAny<Users>()));
        }

        [Fact]
        public void ShouldNotBeAbleToEdituserInformation()
        {
            var reportsMock = new Mock<IReportsRepository>();
            var userMock = new Mock<IUserRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();

            var user = new Users()
            {
                FirstName = "Examplr Name",
                LastName = "Examplr Last Name",
                Email = "user@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            var editUser = new Users()
            {
                FirstName = "Chenged Name",
                LastName = "Chenged Last Name",
                Email = "ChengedUser@example.com",
                Password = "passwordhashhere",
                TeamId = 1
            };

            userMock.Setup(u => u.Read(It.IsAny<int>())).ReturnsAsync((Users)null);

            userMock.Setup(u => u.Update(It.IsAny<Users>()));

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object,reportsMock.Object);

            var result = userService.EditUserInformation(editUser);

            userService.Invoking(x => x.EditUserInformation(editUser)).Should().ThrowAsync<DataException>();
        }


        [Fact]
        public void ShouldBeAbleToReturnListOfReports()
        {
            var userMock = new Mock<IUserRepository>();
            var reportsMock = new Mock<IReportsRepository>();
            var leaderMock = new Mock<ILeaderRepository>();
            var teamMock = new Mock<ITeamRepository>();

            var report = new Reports
            {
                UserId = 1,
                Morale = 1,
                MoraleDescription = "dwadaw",
                Stress = 2,
                StressDescription = "fefe",
                Workload = 3,
                WorkloadDescription = "dwadawd",
                High = "dawdwad",
                Low = "dawdawda",
                AnythingElse = "dawdawdwa",
                DateRangeStart = new DateTime(2022 - 10 - 10),
                DateRangeEnd = new DateTime(2022 - 10 - 10)
            };

            reportsMock.Setup(r => r.GetAllByUserId(It.IsAny<int>())).ReturnsAsync(new List<Reports> { report });

            UserService userService = new UserService(userMock.Object, leaderMock.Object, teamMock.Object, reportsMock.Object);

            var list = userService.ReportsList(2);

            Assert.Equal(2, list.Result[0].Stress);
        }
    }
}
