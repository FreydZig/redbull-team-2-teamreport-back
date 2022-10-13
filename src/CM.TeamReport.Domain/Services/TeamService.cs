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

        public void Add(string teamName)
        {
            var team = new Teams();

            if(string.IsNullOrWhiteSpace(teamName)) throw new TeamExeption(TeamMessages.TeamNameIstCorrect);

            team.TeamName = teamName;
            _teamsRepository.Create(team);
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
