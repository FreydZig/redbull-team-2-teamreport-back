using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult LeaderChose([FromBody] LeaderFromBody leaderFromBody)
        {
            var response = _userService.ChoseLeader(leaderFromBody.TeamId, leaderFromBody.UserId);

            if(response) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("all")]
        public List<UserForLeader> GetAllUsersInTeam(int TeamId)
        {
            var list = _userService.ListUsers(TeamId);

            return list;
        }
    }
}
