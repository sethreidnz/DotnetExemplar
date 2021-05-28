using AutoMapper;
using DotnetExemplar.Api.Models.Database;
using DotnetExemplar.Api.Models.Domain;
using DotnetExemplar.Api.Models.Dto;

namespace DotnetExemplar.Api
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<ReportModel, ReportDto>().ReverseMap();
            CreateMap<ReportModel, ReportEntity>().ReverseMap();
            CreateMap<ReportDto, ReportEntity>().ReverseMap();
        }
    }
}