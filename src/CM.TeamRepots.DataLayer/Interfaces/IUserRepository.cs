using CM.TeamRepots.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public  interface IUserRepository
    {
        void Create(Users entity);

        Users Read(int entityCode);

        void Update(Users entity);

        void Delete(int entityCode);

        List<Users> GetAll();
        Users GetUserByEmail(string email);
    }
}
