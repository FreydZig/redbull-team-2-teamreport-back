using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface ILeaderRepository : IRepository<Leaders>
    {
        public Leaders ReadByTeamId (int teamId);

        public void Delete(int userId, int teamId);
    }
}
