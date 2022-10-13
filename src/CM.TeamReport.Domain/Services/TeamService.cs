using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamReport.Domain.Services
{
    public class TeamService: ITeamService
    {
        private readonly IRepository<Teams> _teamsRepository;

        public TeamService(IRepository<Teams> teamRepository)
        {
            _teamsRepository = teamRepository;
        }

        public async Task<bool> Add(string teamName)
        {
            var team = new Teams();

            if(string.IsNullOrWhiteSpace(teamName)) return false;

            team.TeamName = teamName;
            _teamsRepository.Create(team);

            return true;
        }

        public async Task<bool> Edit(Teams teams)
        {
            if (teams == null ||string.IsNullOrWhiteSpace(teams.TeamName)) return false;

            _teamsRepository.Update(teams);

            return true;
        }
    }
}
