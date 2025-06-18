using AutoMapper;
using CVGenerate.Core.DTOs.PersonalInfo;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class PersonalInfoProfile : Profile
{
    public PersonalInfoProfile()
    {
        CreateMap<PersonalInfoDto, PersonalInfo>().ReverseMap();
    }
}