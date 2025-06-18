using AutoMapper;
using CVGenerate.Core.DTOs.Interest;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class InterestProfile : Profile
{
    public InterestProfile()
    {
        CreateMap<InterestDto, Interest>().ReverseMap();
    }
}