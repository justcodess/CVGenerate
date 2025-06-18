using AutoMapper;
using CVGenerate.Core.DTOs.Language;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageDto, Language>().ReverseMap();
    }
}