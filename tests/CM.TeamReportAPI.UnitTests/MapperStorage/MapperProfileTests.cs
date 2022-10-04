using CM.TeamReportAPI.MapperStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReportAPI.UnitTests.MapperStorage
{
    public class MapperProfileTests
    {
        [Fact]
        public void ShouldBeAbleToCreateMapperProfile()
        {
            MapperProfile m = new MapperProfile();

            Assert.NotNull(m);
        }
    }
}
