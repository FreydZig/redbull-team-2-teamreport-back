
using CM.TeamRepots.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        public Users UserLogin(string email, string password);

        public string GetToken(Users user);

    }
}
