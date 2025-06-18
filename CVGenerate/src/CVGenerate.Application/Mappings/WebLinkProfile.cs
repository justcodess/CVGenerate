using AutoMapper;
using CVGenerate.Core.DTOs.WebLink;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class WebLinkProfile : Profile
{
    public WebLinkProfile()
    {
        CreateMap<WebLinkDto, WebLink>().ReverseMap();
    }
}