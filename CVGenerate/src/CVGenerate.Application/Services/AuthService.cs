using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.User;
using CVGenerate.Core.Entities;
using CVGenerate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CVGenerate.Application.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (userExists)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Bu e-posta ile kayıtlı kullanıcı zaten var."
            };
        }

        var hashed = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            Password = hashed,
            PasswordHash = hashed,
            FullName = dto.FullName
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponseDto
        {
            Success = true,
            Message = "Kayıt başarılı.",
            UserId = user.Id,
            Email = user.Email
        };
    }

    public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Geçersiz e-posta veya şifre."
            };
        }

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Success = true,
            Message = "Giriş başarılı.",
            Token = token,
            UserId = user.Id,
            Email = user.Email
        };
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}