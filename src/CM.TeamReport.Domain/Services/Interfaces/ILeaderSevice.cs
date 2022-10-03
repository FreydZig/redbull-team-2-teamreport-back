using CM.TeamReport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ILeaderSevice
    {
        public void InviteTeam(string email, int TeamId);

        public List<TeamReports> OverallReports(int TeamId);
    }
}
