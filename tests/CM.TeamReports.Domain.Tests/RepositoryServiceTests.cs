using CM.TeamReport.Domain.Services;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Moq;

namespace CM.TeamReports.Domain.Tests
{
    public class RepositoryServiceTests
    {
        [Fact]
        public void ShouldBeAbleToCreateReportsService()
        {
            var reportsMock = new Mock<IReportsRepository>();

            ReportsService reportsService = new ReportsService(reportsMock.Object);

            Assert.NotNull(reportsService);
        }

        [Fact]
        public void ShouldBeAbleToAddNewReport()
        {
            var reportsMock = new Mock<IReportsRepository>();

            ReportsService reportsService = new ReportsService(reportsMock.Object);

            reportsService.AddReport(new Reports());

            Assert.NotNull(reportsService);
        }
    }
}
