using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using System.Data;

namespace CM.TeamReport.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly ILeaderRepository _leaderRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IReportsRepository _reportsRepository;

        public UserService(
            IUserRepository usersRepository,
            ILeaderRepository leaderRepository,
            ITeamRepository teamsRepository,
            IReportsRepository reportsRepository)
        {
            _usersRepository = usersRepository;
            _leaderRepository = leaderRepository;
            _teamRepository = teamsRepository;
            _reportsRepository = reportsRepository;
        }

        public void AddUser(Users user)
        {
            var passwordHashSalt = new PasswordHash().CreatePasswordHash(user.Password);
            user.Password = Convert.ToBase64String(passwordHashSalt.salt) + "." + Convert.ToBase64String(passwordHashSalt.hash) ;
            _usersRepository.Create(user);
        }

        public async Task<bool> ChoseLeader(int teamId, int userId)
        {
            var user = await _usersRepository.Read(userId);
            var team = await _teamRepository.Read(teamId);

            if(user != null && team != null)
            {
                var leader = new Leaders() { TeamId = teamId, UserId = userId };

                _leaderRepository.Delete(userId, teamId);

                _leaderRepository.Create(leader);

                return true;
            }

            return false;
        }

        public async Task<List<UserForLeader>> ListUsers(int teamId)
        {
            var list = await _usersRepository.GetAll(teamId);
            var listUFL = new List<UserForLeader>();

            foreach (var user in list)
            {
                listUFL.Add(new UserForLeader() { UserId = user.UserId, UserName = user.FirstName + ' ' + user.LastName, Title = user.Title });
            }
            
            return listUFL;
        }

        public async Task<Users> EditUserInformation(Users user)
        {
            var userEdit = await _usersRepository.Read(user.UserId);
            if (userEdit == null)
            {
                throw new DataException("Can't find user to edit");
            }

            if(user.FirstName != null)
                userEdit.FirstName = user.FirstName;
            if (user.LastName != null)
                userEdit.LastName = user.LastName;
            if (user.Title != null)
                userEdit.Title = user.Title;


            if(user.TeamId != null)
            {
                var team = _teamRepository.Read((int)user.TeamId);
                if (team == null) throw new DataException("There is no that team!");
                userEdit.TeamId = user.TeamId;
            }           

            _usersRepository.Update(userEdit);

            return userEdit;
        }

        public async Task<List<Reports>> ReportsList(int userId)
        {
            var list = await _reportsRepository.GetAllByUserId(userId);

            return list;
        }
    }
}

