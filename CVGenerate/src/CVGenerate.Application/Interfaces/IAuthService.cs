using CVGenerate.Core.DTOs.User;

namespace CVGenerate.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto);
    Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
}