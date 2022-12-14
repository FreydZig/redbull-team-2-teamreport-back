using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<Users> UserLogin(string email, string password);

        public string GetToken(Users user);

    }
}
