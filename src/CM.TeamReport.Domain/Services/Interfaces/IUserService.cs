using CM.TeamReport.Domain.Models;
using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public void AddUser(Users user);

        public Task<bool> ChoseLeader(int teamId, int userId);

        public Task<List<UserForLeader>> ListUsers(int teamId);

        public Task<Users> EditUserInformation(Users user);

    }
}
