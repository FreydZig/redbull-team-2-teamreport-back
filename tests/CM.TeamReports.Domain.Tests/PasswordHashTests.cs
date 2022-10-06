using CM.TeamReport.Domain;
using FluentAssertions;

namespace CM.TeamReports.Domain.Tests
{
    public class PasswordHashTests
    {
        [Fact]
        public void ShouldBeAbleToCreatePasswordHash()
        {
            PasswordHash passwordHash = new PasswordHash();
            var result = passwordHash.CreatePasswordHash("password");
            result.Should().NotBeNull();

        }
    }
}
