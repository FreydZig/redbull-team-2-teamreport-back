using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
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
        public async Task<string> Registration([FromBody] UserCreateModel userCreateModel)
        {
            var userModel = _mapper.Map<UserCreateModel, Users>(userCreateModel);

            var email = await _userRpository.Read(userCreateModel.Email);

            if (email != null) throw new DataException("This Email is registred!");

            _userService.AddUser(userModel);

            return _authService.GetToken(userModel);
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromBody] UserLogin userLogin)
        {
            var user =  await _authService.UserLogin(userLogin.Email, userLogin.Password);

            return _authService.GetToken(user);
        }

    }
}
