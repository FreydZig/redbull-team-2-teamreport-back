using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface ITeamRepository: IRepository<Teams>
    {
        Task<Teams> ReadByTeamName(string teamName);
        int CreateWithReturn(Teams entity);
    }
}
