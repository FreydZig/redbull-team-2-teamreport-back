using AutoMapper;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CM.TeamReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;
        private readonly IMapper _mapper;

        public ReportsController(IReportsService reportsService, IMapper mapper)
        {
            _reportsService = reportsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult ReportAdd([FromBody] ReportFormBody reportFromBody)
        {
            var report = _mapper.Map<ReportFormBody, Reports>(reportFromBody);

            _reportsService.AddReport(report);

            return Ok();
        }
    }
}
