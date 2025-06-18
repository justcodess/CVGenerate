using AutoMapper;
using CVGenerate.Core.DTOs.WorkExperience;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class WorkExperienceProfile : Profile
{
    public WorkExperienceProfile()
    {
        CreateMap<WorkExperienceDto, WorkExperience>().ReverseMap();
    }
}