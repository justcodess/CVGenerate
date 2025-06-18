using AutoMapper;
using CVGenerate.Core.DTOs.Education;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class EducationProfile : Profile
{
    public EducationProfile()
    {
        CreateMap<EducationDto, Education>().ReverseMap();
    }
}