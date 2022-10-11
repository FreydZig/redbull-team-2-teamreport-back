using CM.TeamReport.Domain.Exceptions;
using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;
using System.Data;

namespace CM.TeamReports.Domain.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAuthService()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var authService = new AuthService(repositoryMock.Object);
            authService.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleTologinUser()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Read(It.IsAny<string>())).ReturnsAsync(new Users() { Email = "example@gmail.com" , Password = "h4Z1snEzaTyYkEhLoNEMxq4NKBmIxRkmz4p2/4s0HYDuAVCAM1UI9NgnxaA1Rl6lUBZILCG76Dfdve+yZIspL0q5eW6ppZ7bfj09j+q3LiAOWz1G5e++7R5c9UqqB9WvYGLR4NruCbVI2biUn4QdzArYimIoFb2saTd6cOJ/a74=.LMpXLuSeU1qIYP5l5Y6EAM9MzimLj0kKttgFoI0z1Sc51I+d9qYMcW+drNcVG8HT4e58/EKgUs7h9NKggA5Q7w==" }); ;
            var authService = new AuthService(repositoryMock.Object);
            var result = authService.UserLogin("example@gmail.com", "pass123");
            result.Should().BeOfType<Task<Users>>();
            
        }
        [Fact]
        public void ShouldNotBeAbleToLogin()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Read(It.IsAny<string>())).ReturnsAsync((Users)null); ;
            var authService = new AuthService(repositoryMock.Object);
            
        }

        [Fact]
        public void ShouldBeIncorrectPassword()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Read(It.IsAny<string>())).ReturnsAsync(new Users() { Email = "example@gmail.com", Password = "h4Z1snEzaTyYkEhLoNEMxq4NKBmIxRkmz4p2/4s0HYDuAVCAM1UI9NgnxaA1Rl6lUBZILCG76Dfdve+yZIspL0q5eW6ppZ7bfj09j+q3LiAOWz1G5e++7R5c9UqqB9WvYGLR4NruCbVI2biUn4QdzArYimIoFb2saTd6cOJ/a74=.LMpXLuSeU1qIYP5l5Y6EAM9MzimLj0kKttgFoI0z1Sc51I+d9qYMcW+drNcVG8HT4e58/EKgUs7h9NKggA5Q7w==" }); ;
            var authService = new AuthService(repositoryMock.Object);
            authService.Invoking(a => a.UserLogin("example@gmail.com", "pass1"))
                .Should().ThrowAsync<LoginException>().WithMessage("Password isn't correct!");
        }

        [Fact]
        public void ShouldBeIncorrectEmail()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Read(It.IsAny<string>())).ReturnsAsync((Users)null); ;
            var authService = new AuthService(repositoryMock.Object);
            authService.Invoking(a => a.UserLogin("example@gmail.com", "pass1"))
                .Should().ThrowAsync<LoginException>().WithMessage("Email isn't correct!");
        }

        [Fact]
        public void ShouldCreateToken()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var authService = new AuthService(repositoryMock.Object);
            Users user = new Users()
            {
                Email = "example@gmail.com",
                Password = "h4Z1snEzaTyYkEhLoNEMxq4NKBmIxRkmz4p2/4s0HYDuAVCAM1UI9NgnxaA1Rl6lUBZILCG76Dfdve+yZIspL0q5eW6ppZ7bfj09j+q3LiAOWz1G5e++7R5c9UqqB9WvYGLR4NruCbVI2biUn4QdzArYimIoFb2saTd6cOJ/a74=.LMpXLuSeU1qIYP5l5Y6EAM9MzimLj0kKttgFoI0z1Sc51I+d9qYMcW+drNcVG8HT4e58/EKgUs7h9NKggA5Q7w=="
            };
            var result = authService.GetToken(user);
            result.Should().NotBeNull();
        }

        [Fact]
        public void ShouldThrowDataException()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var authService = new AuthService(repositoryMock.Object);
            Users user = (Users)null;
            authService.Invoking(a => a.GetToken(user))
                .Should().Throw<DataException>().WithMessage("Data is empty!");
        }
    }
}