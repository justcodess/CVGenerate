using AutoMapper;
using CVGenerate.Core.DTOs.User;
using CVGenerate.Core.Entities;
using Profile = AutoMapper.Profile;

namespace CVGenerate.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterDto, User>();
        CreateMap<User, UserRegisterDto>();
    }
}