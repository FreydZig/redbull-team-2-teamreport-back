using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services
{
    public class LeaderService : ILeaderSevice
    {
        private readonly IUserRepository _userRepository;

        public LeaderService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void InviteTeam(string email, int TeamId)
        {
            var user = _userRepository.Read(email);

            user.TeamId = TeamId;

            _userRepository.Update(user);
        }
    }
}
