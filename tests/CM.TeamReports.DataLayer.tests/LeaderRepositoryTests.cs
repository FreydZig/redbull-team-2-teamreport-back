using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Repositories;
using System;
using Xunit;

namespace CM.TeamReports.DataLayer.tests
{
    public class LeaderRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToGetAllLeaders()
        {
            LeaderRepository leaders = new LeaderRepository();

            var leaders2 = leaders.GetAll();

            Assert.Equal(1, leaders2.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnLeader()
        {
            LeaderRepository leaders = new LeaderRepository();

            var leader = leaders.Read(34);

            Assert.Equal(10, leader.LeaderId);
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

            leaders.Create(new Leaders { TeamId = 14, UserId = 36 });

            Assert.Equal(36, leaders.Read(36).UserId);
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

            leader.Delete(41);

            Assert.Null(leader.Read(41));
        }

        [Fact]
        public void ShouldBeAbleToReadByTeamId()
        {
            LeaderRepository leaderRepository = new LeaderRepository();

            var leader = leaderRepository.ReadByTeamId(14);

            Assert.Equal(14, leader.LeaderId);
        }

        [Fact]
        public void ShouldBeAbleToDeleteLeaderByTwoArgs()
        {
            var leader = new LeaderRepository();

            leader.Delete(34, 13);

            Assert.Null(leader.ReadByTeamId(13));
        }
    }
}
