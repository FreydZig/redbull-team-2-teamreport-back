using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReport.Domain.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Route("previousperiod")]
        public IEnumerable<PreviousReports> PreviousPeriod(int id)
        {
            var list = _leaderService.PreviousReports(id);
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
