using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface IReportsRepository : IRepository<Reports>
    {
        public List<Reports> GetAllByTeamId(int entityCode);
        public List<Reports> GetAllByUserId(int entityCode);
        public Task<int> SumOfUserStates (DateTime start, DateTime end, int entityId);
        public Task<Reports> ReadByUserIdAndPeriod(int entityCode, DateTime start, DateTime end);
        public Task<int> UserState(int entityCode, char state, DateTime start, DateTime end);

    }
}
