using CM.TeamReportAPI.MapperStore;

namespace CM.TeamReportAPI.UnitTests.MapperStorage
{
    public class MapperProfileTests
    {
        [Fact]
        public void ShouldBeAbleToCreateMapperProfile()
        {
            MapperProfile mapperProfile = new MapperProfile();

            Assert.NotNull(mapperProfile);
        }
    }
}
