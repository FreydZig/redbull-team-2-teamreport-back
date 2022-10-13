using CM.TeamReport.Domain.Exceptions;
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

        public async Task Add(string teamName)
        {
            var team = new Teams();

            if(string.IsNullOrWhiteSpace(teamName)) throw new TeamExeption("Team name is't correct!");

            team.TeamName = teamName;
            _teamsRepository.Create(team);
        }

        public async Task Edit(Teams teams)
        {
            if (teams == null) throw new TeamExeption("Team is null!");
            if (string.IsNullOrWhiteSpace(teams.TeamName)) throw new TeamExeption("Team name is't correct!");

            _teamsRepository.Update(teams);
        }
    }
}
