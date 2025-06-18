using AutoMapper;
using CVGenerate.Core.DTOs.Profile;
using CVGenerate.Core.Entities;

namespace CVGenerate.Application.Mappings;

public class ProfileProfile : Profile
{
    public ProfileProfile()
    {
        CreateMap<ProfileDto, Profile>().ReverseMap();
    }
}