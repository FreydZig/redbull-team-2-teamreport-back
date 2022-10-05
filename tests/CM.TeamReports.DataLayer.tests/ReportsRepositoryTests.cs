using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Repositories;
using Xunit;

namespace CM.TeamReports.DataLayer.tests
{
    public class ReportsRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleGetAllReports()
        {
            ReportsRepository reports = new ReportsRepository();

            Assert.NotNull(reports);

            var r = reports.GetAll();

            Assert.Equal(11, r.Count);
        }

        [Fact]
        public void ShouldBeAbleGetAllReportsByTeamId()
        {
            ReportsRepository reports = new ReportsRepository();

            var reports2 = reports.GetAllByTeamId(1);

            Assert.Equal(5, reports2.Count);
        }

        [Fact]
        public void ShouldBeAbleGetAllReportsByUserId()
        {
            ReportsRepository reports = new ReportsRepository();

            var reports2 = reports.GetAllByUserId(13);

            Assert.Equal(0, reports2.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnReport()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.Read(1);

            Assert.Equal(1, report.ReportId);
        }

        [Fact]
        public void ShouldBeAbleToReturnReportByDate()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.ReadByDate(new System.DateTime(2022 , 09 , 14));

            Assert.Equal(15, report.ReportId);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnReportByDate()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.ReadByDate(new System.DateTime(2021, 09, 14));

            Assert.Null(report);
        }

        [Fact]
        public void ShouldBeAbleToReturnReportByPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.SumOfUserStates(new System.DateTime(2021, 09, 14), new System.DateTime(2022, 09, 14), 28);

            Assert.Equal(3, report);
        }

        [Fact]
        public void ShouldBeAbleToReturnReportByUserIdAndPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.ReadByUserId(28);

            Assert.Equal(28, report.UserId);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnReportByUserIdAndPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.ReadByUserId(145);

            Assert.Null(report);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnReportByPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.SumOfUserStates(new System.DateTime(2021, 09, 14), new System.DateTime(2012, 09, 14), 28);

            Assert.Null(report);
        }

        [Fact]
        public void ShouldBeAbleToDeleteReport()
        {
            ReportsRepository reports = new ReportsRepository();

            reports.Delete(9);

            Assert.Null(reports.Read(9));
        }

        [Fact]
        public void ShouldBeAbleToCreateReport()
        {
            ReportsRepository reports = new ReportsRepository();

            reports.Create(new Reports {
                UserId = 28,
                Morale = 2,
                //MoraleDescription = "Wow",
                Stress = 5,
                //StressDescription = "Woow",
                Workload = 3,
               // WorkloadDescription = "Hooh",
                High = "High",
                Low = "Low",
                //AnythingElse = "Nothing",
                DateRange = new System.DateTime(2022, 10, 4)
            });

            Assert.Equal(2, reports.Read(15).Morale);
        }

        [Fact]
        public void ShouldNotBeAbleToUpdateReport()
        {
            ReportsRepository reports = new ReportsRepository();

            Assert.Throws<System.NotImplementedException>(() => reports.Update(new Reports()));
        }
    }
}
