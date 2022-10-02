using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
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
        private readonly IUserRepository _userRepository; 

        public LeaderController(ILeaderSevice leaderSevice, IUserRepository userRepository)
        {
            _leaderService = leaderSevice;
            _userRepository = userRepository;
        }

        //[HttpPost]
        //[Route("invite")]
        //public IActionResult Invite(InviteUser user)
        //{
        //    if(user == null)
        //    {
        //        return BadRequest("Not Valid data!");
        //    }

        //    _leaderService.InviteTeam
        //}

        [HttpGet]
        [Authorize]
        public IResult aa()
        {
            return Results.Json(_userRepository.Read(29));
        }
    }
}
