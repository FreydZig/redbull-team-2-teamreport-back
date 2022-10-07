using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public  interface IUserRepository : IRepository<Users>
    {
        Task<Users> Read(string email);

        Task<List<Users>> GetAll(int entityId);
    }
}
