using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.User;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Enums;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> RegisterAsync(UserRegisterDto dto)
    {
        var existing = await _userRepository.GetByEmailAsync(dto.Email);
        if (existing is not null)
            throw new Exception("Email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = Role.User
        };

        await _userRepository.AddAsync(user);
        return user.Id;
    }

    public async Task<string> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email)
                   ?? throw new Exception("User not found.");

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid password.");

        // JWT üretimi burada yapılmalı
        return "token-goes-here";
    }
}