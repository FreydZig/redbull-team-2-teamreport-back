using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public  interface IUserRepository : IRepository<Users>
    {
        Users Read(string email);

        List<Users> GetAll(int entityId);
    }
}
