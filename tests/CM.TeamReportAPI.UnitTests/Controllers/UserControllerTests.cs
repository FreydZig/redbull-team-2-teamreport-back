using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserController()
        {
            var userMock = new Mock<IUserService>();

            UserController userController = new UserController(userMock.Object);

            Assert.NotNull(userController);
        }

        [Fact]
        public void ShouldBeAbleToChoseLeader()
        {
            var userMock = new Mock<IUserService>();

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(true);

            UserController userController = new UserController(userMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            choseLeader.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotBeAbleToChoseLeader()
        {
            var userMock = new Mock<IUserService>();

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(false);

            UserController userController = new UserController(userMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            choseLeader.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeAbleToReturnListOfUsersForLeader()
        {
            var userMock = new Mock<IUserService>();

            var userForLeader = new UserForLeader
            {
                UserId = 1,
                UserName = "Tom Thomson"
            };

            userMock.Setup(u => u.ListUsers(It.IsAny<int>())).ReturnsAsync(new List<UserForLeader> { userForLeader });

            UserController userController = new UserController(userMock.Object);

            var list = userController.GetAllUsersInTeam(1);

            Assert.Single(list.Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnListOfReports()
        {
            var userMock = new Mock<IUserService>();

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

            userMock.Setup(u => u.ReportsList(It.IsAny<int>())).ReturnsAsync(new List<Reports> { report });

            UserController userController = new UserController(userMock.Object);

            var list = userController.GetAllReports(1);

            Assert.Equal(3, list.Result[0].Workload);
        }
    }
}
