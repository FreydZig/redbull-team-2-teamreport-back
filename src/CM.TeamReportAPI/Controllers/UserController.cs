using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult LeaderChose([FromBody] LeaderFromBody lfb)
        {
            var response = _userService.ChoseLeader(lfb.TeamId, lfb.UserId);

            if(response) return Ok(response);
            return BadRequest(response);
        }
    }
}
