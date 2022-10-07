using CM.TeamReport.Domain.Models;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ILeaderSevice
    {
        //public void InviteTeam(string email, int TeamId);

        public Task<List<OverallReports>> OverallReports(int TeamId);

        public Task<List<PreviousReports>> PreviousReports(int TeamId);

        public Task<List<PreviousReports>> CurentReports(int TeamId);
        public Task<List<OverallReports>> StateSort(int TeamId, char state);

        public Task<bool> IsLeader (int UserId);
    }
}
