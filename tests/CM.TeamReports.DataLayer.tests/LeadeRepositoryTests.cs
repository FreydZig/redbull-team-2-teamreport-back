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

            var leader = leaders.Read(28);

            Assert.Equal(9, leader.LeaderId);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnLeader()
        {
            LeaderRepository leaders = new LeaderRepository();

            var leader = leaders.Read(1);

            Assert.Null(leader);
        }

        [Fact]
        public void ShouldBeAbleToCreateLeader()
        {
            LeaderRepository leaders = new LeaderRepository();

            leaders.Create(new Leaders { TeamId = 1, UserId = 28 });

            Assert.Equal(28, leaders.Read(28).UserId);
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

            leader.Delete(5);

            Assert.Null(leader.Read(5));
        }
    }
}
