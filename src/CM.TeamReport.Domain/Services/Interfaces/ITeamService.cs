using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        public Task<bool> Add(string teamName);
        public Task<bool> Edit(Teams teams);
    }
}
