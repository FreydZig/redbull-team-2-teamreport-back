using CM.TeamReport.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
