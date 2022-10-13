using CM.TeamReport.Domain.Exceptions;
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
        public IActionResult CreateCompany([FromBody] string teamName)
        {
            try
            {
                _teamService.Add(teamName);

                return Ok();
            }
            catch(TeamExeption e)
            {
                return BadRequest(e.Message);
            }
           
            
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditCompany([FromBody] Teams teams)
        {
            try
            {
                _teamService.Edit(teams);

                return Ok();
            }
            catch (TeamExeption e)
            {
                return BadRequest(e.Message);
            }   
        }
    }
}
