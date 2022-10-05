using CM.TeamRepots.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services.Interfaces
{
    public interface IReportsService
    {
        public void AddReport(Reports reports);
    }
}
