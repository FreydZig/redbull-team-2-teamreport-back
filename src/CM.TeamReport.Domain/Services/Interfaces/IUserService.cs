
using CM.TeamRepots.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public void AddUser(Users user);

        public bool ChoseLeader(int teamId, int userId);

    }
}
