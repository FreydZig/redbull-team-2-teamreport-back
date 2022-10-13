using CM.TeamReport.Domain;

namespace CM.TeamReports.Domain.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void ShouldBeAbleToReturnsAllDaysOfWeek()
        {
            Assert.Equal(-1, Utils.DayOfWeekToInt(new DateTime(2022, 10, 10)));
            Assert.Equal(-2, Utils.DayOfWeekToInt(new DateTime(2022, 10, 11)));
            Assert.Equal(-3, Utils.DayOfWeekToInt(new DateTime(2022, 10, 12)));
            Assert.Equal(-4, Utils.DayOfWeekToInt(new DateTime(2022, 10, 13)));
            Assert.Equal(-5, Utils.DayOfWeekToInt(new DateTime(2022, 10, 14)));
            Assert.Equal(-6, Utils.DayOfWeekToInt(new DateTime(2022, 10, 15)));
            Assert.Equal(-7, Utils.DayOfWeekToInt(new DateTime(2022, 10, 16))); 
        }
    }
}
