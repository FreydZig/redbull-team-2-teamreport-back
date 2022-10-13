using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface ITeamRepository: IRepository<Teams>
    {
        public Task<Teams> ReadByTeamName(string teamName);
    }
}
