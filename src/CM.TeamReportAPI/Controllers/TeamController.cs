using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateCompany([FromBody] string teamName)
        {
            var answer = await _teamService.Add(teamName);

            if(answer)
            return Ok();
            return BadRequest("Request is't correct!");
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditCompany([FromBody] Teams teams)
        {
            var answer = await _teamService.Edit(teams);

            if (answer)
                return Ok();
            return BadRequest("Request is't correct!");
        }
    }
}
