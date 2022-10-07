using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReport.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        private readonly ILeaderSevice _leaderService; 

        public LeaderController(ILeaderSevice leaderSevice)
        {
            _leaderService = leaderSevice;
        }


        [HttpGet]
        [Route("olderreports")]
        public IEnumerable<OverallReports> OlderReports(int id)
        {
            var list = _leaderService.OverallReports(id);
            return list;
        }

        [HttpGet]
        [Route("olderreports/morale")]
        public IEnumerable<OverallReports> OlderReportsMorale(int id)
        {
            var list = _leaderService.StateSort(id, 'M');
            return list;
        }

        [HttpGet]
        [Route("olderreports/stress")]
        public IEnumerable<OverallReports> OlderReportsStress(int id)
        {
            var list = _leaderService.StateSort(id, 'S');
            return list;
        }

        [HttpGet]
        [Route("olderreports/workload")]
        public IEnumerable<OverallReports> OlderReportsWorkload(int id)
        {
            var list = _leaderService.StateSort(id, 'W');
            return list;
        }

        [HttpGet]
        [Route("previousperiod")]
        public IEnumerable<PreviousReports> PreviousPeriod(int id)
        {
            var list = _leaderService.PreviousReports(id);
            return list;
        }

        [HttpGet]
        [Route("curentperiod")]
        public IEnumerable<PreviousReports> CurentPeriod(int id)
        {
            var list = _leaderService.CurentReports(id);
            return list;
        }

        [HttpGet]
        [Route("check")]
        public bool Check(int id)
        {
            return _leaderService.IsLeader(id);
        }
    }
}
