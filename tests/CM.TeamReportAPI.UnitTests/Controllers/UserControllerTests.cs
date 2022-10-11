using AutoMapper;
using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserController()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            Assert.NotNull(userController);
        }

        [Fact]
        public void ShouldBeAbleToChoseLeader()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(true);

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            choseLeader.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotBeAbleToChoseLeader()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            userMock.Setup(u => u.ChoseLeader(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(false);

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            var choseLeader = userController
                .LeaderChose(new LeaderFromBody());

            choseLeader.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeAbleToReturnListOfUsersForLeader()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            var userForLeader = new UserForLeader
            {
                UserId = 1,
                UserName = "Tom Thomson"
            };

            userMock.Setup(u => u.ListUsers(It.IsAny<int>())).ReturnsAsync(new List<UserForLeader> { userForLeader });

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            var list = userController.GetAllUsersInTeam(1);

            Assert.Single(list.Result);
        }

        [Fact]
        public void ShouldBeAbleToEditUser()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            var editUserModel = new EditUserInformationModel() { FirstName = "Edited", LastName = "Edited", Title = "Edited" };

            var user = new Users() { FirstName = "Edited", LastName = "Edited", Title = "Edited" };

            mapperMock.Setup(m => m.Map<EditUserInformationModel, Users>(editUserModel)).Returns(user);

            userMock.Setup(u => u.EditUserInformation(It.IsAny<Users>()));

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            var result = userController.EditUserInformation(editUserModel);
            result.Result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void ShouldNotBeAbleToEditUser()
        {
            var userMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();

            var editUserModel = (EditUserInformationModel)null; 

            var user = new Users() { FirstName = "Edited", LastName = "Edited", Title = "Edited" };

            mapperMock.Setup(m => m.Map<EditUserInformationModel, Users>(editUserModel)).Returns(user);

            userMock.Setup(u => u.EditUserInformation(It.IsAny<Users>()));

            UserController userController = new UserController(userMock.Object, mapperMock.Object);

            var result = userController.EditUserInformation(editUserModel);

            result.Result.Should().BeOfType<BadRequestObjectResult>();
        } 
    }
}
