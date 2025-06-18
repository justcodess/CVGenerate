using CVGenerate.Core.DTOs.Profile;

namespace CVGenerate.Application.Interfaces;

public interface IProfileService
{
    Task<ProfileDto?> GetByUserIdAsync(Guid userId);
    Task<Guid> UpsertAsync(Guid userId, ProfileDto dto);
    Task DeleteAsync(Guid userId);
}