using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;
using System.Data;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class AuthenticationControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserController()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);

            Assert.NotNull(controller);
        }

        [Fact]
        public void ShouldBeAbleToRegistration()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var userCreateModel = new UserCreateModel()
            {
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Title = "Title",
                Password = "dadsadasd"
            };

            var user = new Users()
            {
                UserId = 1,
                FirstName = userCreateModel.FirstName,
                LastName = userCreateModel.LastName,
                Email = userCreateModel.Email,
                Title = userCreateModel.Title,
                Password = userCreateModel.Password
            };

            mapper.Setup(m => m.Map<UserCreateModel, Users>(It.IsAny<UserCreateModel>())).Returns(user);

            userRpository.Setup(u => u.Read(userCreateModel.Email)).Returns((Task<Users>)null);

            authService.Setup(a => a.GetToken(user)).Returns("dsadwdwadwada");

            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);

            Assert.Equal("Title", userCreateModel.Title);
            Assert.NotNull(controller.Registration(userCreateModel));
        }

        [Fact]
        public void SHouldBeAbleToSignUp()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var userCreateModel = new UserCreateModel()
            {
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Title = "Title",
                Password = "dadsadasd"
            };

            var user = new Users()
            {
                UserId = 1,
                FirstName = userCreateModel.FirstName,
                LastName = userCreateModel.LastName,
                Email = userCreateModel.Email,
                Title = userCreateModel.Title,
                Password = userCreateModel.Password
            };

            mapper.Setup(m => m.Map<UserCreateModel, Users>(It.IsAny<UserCreateModel>())).Returns(user);

            userService.Setup(u => u.AddUser(It.IsAny<Users>()));

            userRpository.Setup(u => u.Read(userCreateModel.Email)).ReturnsAsync((Users)null);

            authService.Setup(a => a.GetToken(user)).Returns("dsadwdwadwada");

            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);

            Assert.Equal("Title", userCreateModel.Title);

            var result = controller.Registration(userCreateModel);

            result.Should().BeOfType<Task<string>>();
        }

        [Fact]
        public void ShouldNotBeAbleToRegistration()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var userCreateModel = new UserCreateModel()
            {
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Password = "dadsadasd"
            };

            var user = new Users()
            {
                UserId = 1,
                FirstName = userCreateModel.FirstName,
                LastName = userCreateModel.LastName,
                Email = userCreateModel.Email,
                Password = userCreateModel.Password
            };

            mapper.Setup(m => m.Map<UserCreateModel, Users>(It.IsAny<UserCreateModel>())).Returns(user);

            userRpository.Setup(u => u.Read(userCreateModel.Email)).ReturnsAsync(user);


            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);


            Assert.ThrowsAsync<DataException>(() => controller.Registration(userCreateModel));
        }

        [Fact]
        public void ShouldBeAbleToLoginUser()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var user = new Users()
            {
                UserId = 1,
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Password = "dadsadasd"
            };

            var ul = new UserLogin()
            {
                Email = "z@mail.com",
                Password = "dadsadasd"
            };

            authService.Setup(a => a.GetToken(user)).Returns("dsadwdwadwada");

            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);
                       
            authService.Setup(a => a.UserLogin(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

            Assert.NotNull(controller.Login(ul));
        }
    }
}
