using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface IReportsRepository : IRepository<Reports>
    {
        public List<Reports> GetAllByTeamId(int entityCode);
        public List<Reports> GetAllByUserId(int entityCode);
        public int SumOfUserStates (DateTime start, DateTime end, int entityId);
        public Reports ReadByUserIdAndPeriod(int entityCode, DateTime start, DateTime end);
        public int UserState(int entityCode, char state, DateTime start, DateTime end);

    }
}
