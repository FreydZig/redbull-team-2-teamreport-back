using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public  interface IUserRepository : IRepository<Users>
    {
        //void Create(Users entity);

        Users Read(string email);

        //void Update(Users entity);

        //void Delete(int entityCode);

        List<Users> GetAll(int entityId);

        //Users GetUserByEmail(string email);
    }
}
