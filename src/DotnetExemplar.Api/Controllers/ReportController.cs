using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetExemplar.Api.Models.Dto;
using DotnetExemplar.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetExemplar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IMapper _mappper;
        private readonly ReportService _reportService;

        public ReportController(
            ILogger<ReportService> logger,
            IMapper mapper,
            ReportService reportService)
        {
            _logger = logger;
            _mappper = mapper;
            _reportService = reportService;
        }

        [HttpGet("{tenantId}")]
        public ActionResult<ReportDto> GetReport(Guid tenantId)
        {
            _logger.LogInformation("{methodName} called with {tenantId}", nameof(ReportService.GetReport), tenantId);
            try
            {
                var report = _reportService.GetReport(tenantId);
                return Ok(_mappper.Map<ReportDto>(report));
            }
            catch (Exception exception)
            {
                _logger.LogError("There was an error getting the report for <tenantId>={tenantId} '{message}'", tenantId, exception.Message);
                throw;
            }
        }
    }
}
