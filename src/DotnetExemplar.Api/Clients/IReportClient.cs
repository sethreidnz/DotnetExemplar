using System;
using DotnetExemplar.Api.Models.Dto;

namespace DotnetExemplar.Api.Clients
{
    public interface IReportClient
    {
        ReportDto GetReport(Guid tenantId);
    }
}
