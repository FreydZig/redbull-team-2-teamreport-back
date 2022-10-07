using CM.TeamReport.Domain.Models;
using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public void AddUser(Users user);

        public bool ChoseLeader(int teamId, int userId);

        public List<UserForLeader> ListUsers(int teamId);

    }
}
