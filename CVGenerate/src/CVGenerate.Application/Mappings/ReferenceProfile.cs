using AutoMapper;
using CVGenerate.Core.DTOs.Reference;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class ReferenceProfile : Profile
{
    public ReferenceProfile()
    {
        CreateMap<ReferenceDto, Reference>().ReverseMap();
    }
}