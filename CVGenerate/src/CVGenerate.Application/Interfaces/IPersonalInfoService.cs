using CVGenerate.Core.DTOs.PersonalInfo;

namespace CVGenerate.Application.Interfaces;

public interface IPersonalInfoService
{
    Task<PersonalInfoDto?> GetByUserIdAsync(Guid userId);
    Task<Guid> UpsertAsync(Guid userId, PersonalInfoDto dto);
    Task DeleteAsync(Guid userId);
}