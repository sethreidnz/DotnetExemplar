using System;
using DotnetExemplar.Api.Models.Domain;

namespace DotnetExemplar.Api.Services
{
    public interface IReportService
    {
        ReportModel GetReport(Guid tenantId);
    }
}
