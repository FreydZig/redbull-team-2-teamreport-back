using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
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

            var ucm = new Models.UserCreateModel()
            {
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Password = "dadsadasd"
            };

            var user = new Users()
            {
                UserId = 1,
                FirstName = ucm.FirstName,
                LastName = ucm.LastName,
                Email = ucm.Email,
                Password = ucm.Password
            };

            mapper.Setup(m => m.Map<UserCreateModel, Users>(It.IsAny<UserCreateModel>())).Returns(user);

            userRpository.Setup(u => u.Read(ucm.Email)).Returns((Users)null);

            authService.Setup(a => a.GetToken(user)).Returns("dsadwdwadwada");

            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);


            Assert.NotNull(controller.Registration(ucm));
        }

        [Fact]
        public void ShouldNotBeAbleToRegistration()
        {
            var authService = new Mock<IAuthService>();
            var userService = new Mock<IUserService>();
            var userRpository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var ucm = new Models.UserCreateModel()
            {
                FirstName = "Men",
                LastName = "NoMen",
                Email = "z@mail.com",
                Password = "dadsadasd"
            };

            var user = new Users()
            {
                UserId = 1,
                FirstName = ucm.FirstName,
                LastName = ucm.LastName,
                Email = ucm.Email,
                Password = ucm.Password
            };

            mapper.Setup(m => m.Map<UserCreateModel, Users>(It.IsAny<UserCreateModel>())).Returns(user);

            userRpository.Setup(u => u.Read(ucm.Email)).Returns(user);


            AuthenticationController controller = new AuthenticationController(authService.Object, userService.Object, userRpository.Object, mapper.Object);


            Assert.Throws<DataException>(() => controller.Registration(ucm));
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
                       
            authService.Setup(a => a.UserLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            Assert.NotNull(controller.Login(ul));
        }
    }
}
