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
        public async Task<List<OverallReports>> OlderReports(int id)
        {
            var list = await _leaderService.OverallReports(id);
            return list;
        }

        [HttpGet]
        [Route("olderreports/morale")]
        public async Task<List<OverallReports>> OlderReportsMorale(int id)
        {
            var list = await _leaderService.StateSort(id, 'M');
            return list;
        }

        [HttpGet]
        [Route("olderreports/stress")]
        public async Task<List<OverallReports>> OlderReportsStress(int id)
        {
            var list = await _leaderService.StateSort(id, 'S');
            return list;
        }

        [HttpGet]
        [Route("olderreports/workload")]
        public async Task<List<OverallReports>> OlderReportsWorkload(int id)
        {
            var list = await _leaderService.StateSort(id, 'W');
            return list;
        }

        [HttpGet]
        [Route("previousperiod")]
        public async Task<List<PreviousReports>> PreviousPeriod(int id)
        {
            var list = await _leaderService.PreviousReports(id);
            return list;
        }

        [HttpGet]
        [Route("curentperiod")]
        public async Task<List<PreviousReports>> CurentPeriod(int id)
        {
            var list = await _leaderService.CurentReports(id);
            return list;
        }

        [HttpGet]
        [Route("check")]
        public async Task<bool> Check(int id)
        {
            return await _leaderService.IsLeader(id);
        }
    }
}
