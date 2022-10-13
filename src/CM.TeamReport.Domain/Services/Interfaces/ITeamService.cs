using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        void Add(string teamName);
        void Edit(Teams teams);
    }
}
