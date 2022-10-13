using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        int Add(string teamName);
        void Edit(Teams teams);
        Task<Teams> Get(int teamId);
    }
}
