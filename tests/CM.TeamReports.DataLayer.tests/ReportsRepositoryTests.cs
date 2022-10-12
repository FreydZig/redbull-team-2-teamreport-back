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

            var reports2 = reports.GetAllByUserId(34);

            Assert.Equal(5, reports2.Result.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnReport()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.Read(31);

            Assert.Equal(31, report.Result.ReportId);
        }

        [Fact]
        public void ShouldBeAbleToReturnReportByPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.SumOfUserStates(System.DateTime.Now.AddDays(-3), System.DateTime.Now, 34);

            Assert.Equal(1, report.Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnReportByUserIdAndPeriod()
        {
            ReportsRepository reports = new ReportsRepository();
            //TODO: Fix this test and tests under him
            var report = reports.ReadByUserIdAndPeriod(34, System.DateTime.Now, System.DateTime.Now.AddDays(-3));

            Assert.Equal(34, report.Result.UserId);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnReportByUserIdAndPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.ReadByUserIdAndPeriod(31, System.DateTime.Now, System.DateTime.Now.AddDays(-3));

            Assert.Null(report);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnReportByPeriod()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.SumOfUserStates(new System.DateTime(2021, 09, 14), new System.DateTime(2012, 09, 14), 31);

            Assert.Equal(0, report.Result);
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
                DateRangeStart = new System.DateTime(2022, 10, 4),
                DateRangeEnd = new System.DateTime(2022,10,5)
            });

            Assert.Equal(2, reports.Read(15).Result.Morale);
        }

        [Fact]
        public void ShouldNotBeAbleToUpdateReport()
        {
            ReportsRepository reports = new ReportsRepository();

            Assert.Throws<System.NotImplementedException>(() => reports.Update(new Reports()));
        }

        [Fact]
        public void ShouldBeAbleToReturnUserMorale()
        {
            ReportsRepository reports = new ReportsRepository();

            var morale = reports.UserState(37, 'M', System.DateTime.Now.AddDays(-4), System.DateTime.Now);

            Assert.Equal(4, morale.Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnUserStress()
        {
            ReportsRepository reports = new ReportsRepository();

            var stress = reports.UserState(37, 'S', System.DateTime.Now.AddDays(-4), System.DateTime.Now);

            Assert.Equal(2, stress.Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnUserWorkload()
        {
            ReportsRepository reports = new ReportsRepository();

            var workload = reports.UserState(37, 'W', System.DateTime.Now.AddDays(-4), System.DateTime.Now);

            Assert.Equal(5, workload.Result);
        }

        [Fact]
        public void ShouldBeAbleToReturnUserStateLikeZero()
        {
            ReportsRepository reports = new ReportsRepository();

            var state = reports.UserState(37, 'f', System.DateTime.Now.AddDays(-4), System.DateTime.Now);

            Assert.Equal(0, state.Result);
        }
    }
}
