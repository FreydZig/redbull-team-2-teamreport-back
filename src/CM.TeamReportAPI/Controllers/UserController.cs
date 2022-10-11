﻿using CM.TeamReport.Domain.Models;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        [HttpGet]
        [Route("reports")]
        public async Task<List<Reports>> GetAllReports(int UserId)
        {
            var list = await _userService.ReportsList(UserId);

            return list;
        }
    }
}
