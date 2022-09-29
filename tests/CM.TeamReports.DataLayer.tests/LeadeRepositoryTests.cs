using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Repositories;
using System;
using Xunit;

namespace CM.TeamReports.DataLayer.tests
{
    public class LeadeRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToGetAllLeaders()
        {
            LeaderRepository leaders = new LeaderRepository();

            var leaders2 = leaders.GetAll();

            Assert.Equal(4, leaders2.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnLeader()
        {
            LeaderRepository leaders = new LeaderRepository();

            var leader = leaders.Read(1);

            Assert.Equal(1, leader.LeaderId);
        }

        [Fact]
        public void ShouldBeAbleToCreateLeader()
        {
            LeaderRepository leaders = new LeaderRepository();

            leaders.Create(new Leaders { TeamId = 4, UserId = 12 });

            Assert.Equal(12, leaders.Read(1).UserId);
        }

        [Fact]
        public void ShouldBeAbleToUpdateLeader()
        {
            LeaderRepository leader = new LeaderRepository();

            Assert.Throws<NotImplementedException>(() => leader.Update(new Leaders { }));
        }

        [Fact]
        public void ShouldBeAbleToDeleteLeader()
        {
            LeaderRepository leader = new LeaderRepository();

            leader.Delete(4);

            Assert.Null(leader.Read(4));
        }
    }
}
