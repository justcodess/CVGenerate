using AutoMapper;
using CVGenerate.Core.DTOs.CustomSection;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class CustomSectionProfile : Profile
{
    public CustomSectionProfile()
    {
        CreateMap<CustomSectionDto, CustomSection>().ReverseMap();
    }
}