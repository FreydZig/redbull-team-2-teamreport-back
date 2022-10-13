using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        Task<int> Add(string teamName);
        void Edit(Teams teams);
    }
}
