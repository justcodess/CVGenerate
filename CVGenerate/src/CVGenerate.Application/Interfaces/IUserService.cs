using CVGenerate.Core.DTOs.User;

namespace CVGenerate.Application.Interfaces;

public interface IUserService
{
    Task<Guid> RegisterAsync(UserRegisterDto dto);
    Task<string> LoginAsync(UserLoginDto dto);
}