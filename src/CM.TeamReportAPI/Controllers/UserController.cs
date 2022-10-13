using AutoMapper;
using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> LeaderChose([FromBody] LeaderFromBody leaderFromBody)
        {
            var response = await _userService.ChoseLeader(leaderFromBody.TeamId, leaderFromBody.UserId);

            if(response) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<UserForLeader>> GetAllUsersInTeam(int TeamId)
        {
            var list = await _userService.ListUsers(TeamId);

            return list;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUserInformation(EditUserInformationModel request)
        {
            if (request == null)
            {
                return BadRequest("Can't find user to edit");
            }
            var model = _mapper.Map<EditUserInformationModel, Users>(request);
            var editModel = await _userService.EditUserInformation(model);
            return Ok(editModel);
        } 

        [HttpGet]
        [Route("reports")]
        public async Task<List<Reports>> GetAllReports(int UserId)
        {
            var list = await _userService.ReportsList(UserId);

            return list;
        }
    }
}
