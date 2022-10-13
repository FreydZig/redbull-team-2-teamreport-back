using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        public Task Add(string teamName);
        public Task Edit(Teams teams);
    }
}
