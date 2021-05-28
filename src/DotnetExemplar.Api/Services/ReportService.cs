using System;
using AutoMapper;
using DotnetExemplar.Api.Clients;
using DotnetExemplar.Api.Models.Domain;
using Microsoft.Extensions.Logging;

namespace DotnetExemplar.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IMapper _mapper;
        private readonly IReportClient _reportClient;

        public ReportService(
            ILogger<ReportService> logger,
            IMapper mapper,
            IReportClient reportClient)
        {
            _logger = logger;
            _mapper = mapper;
            _reportClient = reportClient;
        }

        public ReportModel GetReport(Guid tenantId)
        {
            _logger.LogInformation("{MethodName} called with {TenantId}", nameof(GetReport), tenantId);
            var reportDto = _reportClient.GetReport(tenantId);
            return _mapper.Map<ReportModel>(reportDto);
        }
    }
}
