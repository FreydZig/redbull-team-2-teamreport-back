using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Controllers;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CM.TeamReportAPI.UnitTests.Controllers
{
    public class ReportsControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateReportsController()
        {
            var reportMock = new Mock<IReportsService>();
            var mapperMock = new Mock<IMapper>();

            ReportsController reportsController = new ReportsController(reportMock.Object, mapperMock.Object);

            Assert.NotNull(reportsController);
        }

        [Fact]
        public void ShouldBeAbleToAddNewReport()
        {
            var reportMock = new Mock<IReportsService>();
            var mapperMock = new Mock<IMapper>();

            var reportsFromBody = new ReportFormBody
            {
                UserId = 1,
                Morale = 2,
                MoraleDescription = "dawdwadwad",
                Stress = 4,
                StressDescription = "dawdwadawdawd",
                Workload = 1,
                WorkloadDescription = "dawdawdagag",
                High = "dawdawgagb",
                Low = "hgtddthhd",
                AnythingElse = "agqbsabae3sfa",
                DateRangeStart = new DateTime(),
                DateRangeEnd = new DateTime().AddHours(1)
            };

            var report = new Reports
            {
                ReportId = 1,
                UserId = 1,
                Morale = 2,
                MoraleDescription = "dawdwadwad",
                Stress = 4,
                StressDescription = "dawdwadawdawd",
                Workload = 1,
                WorkloadDescription = "dawdawdagag",
                High = "dawdawgagb",
                Low = "hgtddthhd",
                AnythingElse = "agqbsabae3sfa",
                DateRangeStart = new DateTime(),
                DateRangeEnd = new DateTime().AddHours(1)
            };

            mapperMock.Setup(m => m.Map<ReportFormBody, Reports>(reportsFromBody)).Returns(report);

            ReportsController reportsController = new ReportsController(reportMock.Object, mapperMock.Object);

            var okAnswer = reportsController.ReportAdd(reportsFromBody);

            okAnswer.Result.Should().BeOfType<OkResult>();
        }
    }
}
