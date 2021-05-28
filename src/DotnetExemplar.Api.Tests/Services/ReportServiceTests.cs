using DotnetExemplar.Api.Services;
using DotnetExemplar.Api.Clients;
using DotnetExemplar.Api.Models.Dto;
using Xunit;
using Moq;
using System;
using FluentAssertions;

namespace DotnetExemplar.Api.Tests.Services
{
    public class ReportServiceTests
    {
        [Theory, AutoMoqData]
        public void IsIReportServiceInterface(ReportService sut)
        {
            Assert.IsAssignableFrom<IReportService>(sut);
        }


        [Theory, AutoMoqData]
        public void CreateCustomer_CanCreateCustomer(
            ReportService sut,
            Mock<IReportClient> reportClientMock,
            Guid tenantId,
            ReportDto report)
        {
            // arrange
            reportClientMock
                .Setup(c => c.GetReport(It.IsAny<Guid>()))
                .Returns(report);

            // act
            var result = sut.GetReport(tenantId);

            // assert
            result.Name.Should().Be(report.Name);
        }
    }
}
