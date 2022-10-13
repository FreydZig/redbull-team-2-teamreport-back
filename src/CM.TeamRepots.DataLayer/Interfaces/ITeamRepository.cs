using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface ITeamRepository: IRepository<Teams>
    {
        Task<Teams> ReadByTeamName(string teamName);
        Task<Teams> CreateWithReturn(Teams entity);
    }
}
