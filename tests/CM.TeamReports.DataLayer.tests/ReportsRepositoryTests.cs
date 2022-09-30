﻿using CM.TeamRepots.DataLayer.Entity;
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

            var reports2 = reports.GetAll();

            Assert.Equal(8, reports2.Count);
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

            Assert.Equal(3, reports2.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnReport()
        {
            ReportsRepository reports = new ReportsRepository();

            var report = reports.Read(1);

            Assert.Equal(1, report.ReportId);
        }

        [Fact]
        public void ShouldBeAbleToDeleteReport()
        {
            ReportsRepository reports = new ReportsRepository();

            reports.Delete(8);

            Assert.Null(reports.Read(8));
        }

        [Fact]
        public void ShouldBeAbleToCreateReport()
        {
            ReportsRepository reports = new ReportsRepository();

            reports.Create(new Reports {
                UserId = 14,
                Morale = 2,
                MoraleDescription = "Wow",
                Stress = 5,
                StressDescription = "Woow",
                Workload = 3,
                WorkloadDescription = "Hooh",
                High = "High",
                Low = "Low",
                AnythingElse = "Nothing",
                DateRange = new System.DateTime(2022, 09, 14)
            });

            Assert.Equal(2, reports.Read(10).Morale);
        }
    }
}