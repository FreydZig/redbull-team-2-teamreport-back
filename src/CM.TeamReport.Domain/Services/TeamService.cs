using CM.TeamReport.Domain.Exceptions;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamReport.Domain.Services
{
    public class TeamService: ITeamService
    {
        private readonly ITeamRepository _teamsRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamsRepository = teamRepository;
        }

        public async Task<int> Add(string teamName)
        {
            var team = new Teams();

            if(string.IsNullOrWhiteSpace(teamName)) throw new TeamExeption(TeamMessages.TeamNameIstCorrect);

            team.TeamName = teamName;
            _teamsRepository.Create(team);

            var teamId = await _teamsRepository.ReadByTeamName(teamName);

            return teamId.TeamId;
        }

        public void Edit(Teams teams)
        {
            string? message = null;
            if (teams == null) message = "Team is null!";
            else
                if (string.IsNullOrWhiteSpace(teams.TeamName)) message = TeamMessages.TeamNameIstCorrect;

            if (!string.IsNullOrWhiteSpace(message)) throw new TeamExeption(message);

            _teamsRepository.Update(teams);
        }
    }
}
