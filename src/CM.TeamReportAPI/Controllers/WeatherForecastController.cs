using AutoMapper;
using CM.TeamReport.Domain.Services;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRpository;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _userRpository = userRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public string Post([FromBody] UserCreateModel ucm)
        {
            var userModel = _mapper.Map<UserCreateModel, Users>(ucm);

            var email = ucm.Email;

            _userService.AddUser(userModel);

            string password = _userRpository.Read(email).Password;

            return password;
        }
    }
}