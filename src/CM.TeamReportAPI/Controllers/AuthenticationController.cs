using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRpository;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthService authService, IUserService userService, IUserRepository userRepository, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _userRpository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registration")]
        public string Registration([FromBody] UserCreateModel ucm)
        {
            var userModel = _mapper.Map<UserCreateModel, Users>(ucm);

            var email = _userRpository.Read(userModel.Email);

            if (email != null) throw new DataException("It Email is registred!");

            _userService.AddUser(userModel);

            return _authService.GetToken(userModel);
        }

        [HttpPost]
        [Route("login")]
        public string Login([FromBody] UserLogin login)
        {
            var user = _authService.UserLogin(login.Email, login.Password);

            return _authService.GetToken(user);
        }

    }
}
