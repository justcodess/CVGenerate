using AutoMapper;
using CVGenerate.Core.DTOs.Profile;
using CVGenerate.Core.Entities;

namespace CVGenerate.Application.Mappings;

public class ProfileProfile : AutoMapper.Profile
{
    public ProfileProfile()
    {
        CreateMap<ProfileDto, CVGenerate.Core.Entities.Profile>().ReverseMap();
    }
}