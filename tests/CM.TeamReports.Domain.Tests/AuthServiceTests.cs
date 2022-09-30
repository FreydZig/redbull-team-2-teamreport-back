using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using FluentAssertions;
using Moq;
using System.Security.Cryptography.X509Certificates;

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
    }
}