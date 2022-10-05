using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;

namespace CM.TeamReport.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly ILeaderRepository _leaderRepository;
        private readonly IRepository<Teams> _teamRepository;

        public UserService(IUserRepository usersRepository, ILeaderRepository leaderRepository, IRepository<Teams> teamsRepository)
        {
            _usersRepository = usersRepository;
            _leaderRepository = leaderRepository;
            _teamRepository = teamsRepository;
        }

        public void AddUser(Users user)
        {
            var passwordHashSalt = new PasswordHash().CreatePasswordHash(user.Password);
            user.Password = Convert.ToBase64String(passwordHashSalt.salt) + "." + Convert.ToBase64String(passwordHashSalt.hash) ;
            _usersRepository.Create(user);
        }

        public bool ChoseLeader(int teamId, int userId)
        {
            var user = _usersRepository.Read(userId);
            var team = _teamRepository.Read(teamId);

            if(user != null && team != null)
            {
                var leader = new Leaders() { TeamId = teamId, UserId = userId };

                _leaderRepository.Delete(userId);

                _leaderRepository.Create(leader);

                return true;
            }

            return false;
        }

        public List<UserForLeader> ListUsers(int teamId)
        {
            var list = _usersRepository.GetAll(teamId);
            var listUFL = new List<UserForLeader>();

            foreach (var user in list)
            {
                listUFL.Add(new UserForLeader() { UserId = user.UserId, UserName = user.FirstName + ' ' + user.LastName });
            }
            
            return listUFL;
        }
    }
}

