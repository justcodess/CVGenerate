using CVGenerate.Core.DTOs.CustomSection;

namespace CVGenerate.Application.Interfaces;

public interface ICustomSectionService
{
    Task<List<CustomSectionDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, CustomSectionDto dto);
    Task DeleteAsync(Guid id);
}