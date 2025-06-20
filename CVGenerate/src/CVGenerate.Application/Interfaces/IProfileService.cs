using CVGenerate.Core.DTOs.Profile;

namespace CVGenerate.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileResponseDto> CreateAsync(ProfileCreateDto dto);
        Task<ProfileResponseDto> UpdateAsync(ProfileUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<ProfileResponseDto?> GetByIdAsync(Guid id);
        Task<List<ProfileResponseDto>> GetByUserIdAsync(Guid userId);
    }
}