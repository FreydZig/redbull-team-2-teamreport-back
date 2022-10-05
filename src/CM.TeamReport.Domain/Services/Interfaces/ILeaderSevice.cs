﻿using CM.TeamReport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface ILeaderSevice
    {
        //public void InviteTeam(string email, int TeamId);

        public List<OverallReports> OverallReports(int TeamId);

        public List<PreviousReports> PreviousReports(int TeamId);

        public List<PreviousReports> CurentReports(int TeamId);
        public List<OverallReports> StateSort(int TeamId, char state);

        public bool IsLeader (int UserId);
    }
}
