using AutoMapper;
using CM.TeamReport.Domain.Models;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EmailController(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(InviteMemberModel member)
        {
            var request = _mapper.Map<InviteMemberModel, InviteMember>(member);
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
