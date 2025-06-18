using AutoMapper;
using CVGenerate.Core.DTOs.Skill;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<SkillDto, Skill>().ReverseMap();
    }
}