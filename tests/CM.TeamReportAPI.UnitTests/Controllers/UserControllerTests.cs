using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
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

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            UserController userController = new UserController(userMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            Assert.True(choseLeader is OkObjectResult);
        }

        [Fact]
        public void ShouldNotBeAbleToChoseLeader()
        {
            var userMock = new Mock<IUserService>();

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            UserController userController = new UserController(userMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            Assert.True(choseLeader is BadRequestObjectResult);
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

            userMock.Setup(u => u.ListUsers(It.IsAny<int>())).Returns(new List<UserForLeader> { userForLeader });

            UserController userController = new UserController(userMock.Object);

            var list = userController.GetAllUsersInTeam(1);

            Assert.Single(list);
        }
    }
}
