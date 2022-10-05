using CM.TeamRepots.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamRepots.DataLayer.Interfaces
{
    public interface IReportsRepository : IRepository<Reports>
    {
        public List<Reports> GetAllByTeamId(int entityCode);
        public List<Reports> GetAllByUserId(int entityCode);
        public Reports ReadByDate (DateTime date);
        public int SumOfUserStates (DateTime start, DateTime end, int entityId);
        public Reports ReadByUserIdAndPeriod(int entityCode, DateTime start, DateTime end);
        public int UserState(int entityCode, char state, DateTime start, DateTime end);

    }
}
