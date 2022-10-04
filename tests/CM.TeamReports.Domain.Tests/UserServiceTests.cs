using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReports.Domain.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateUserService()
        {
            var repositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(repositoryMock.Object);
            userService.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToAddUser()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(r => r.Create(It.IsAny<Users>()));
            UserService userService = new UserService(repositoryMock.Object);
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
