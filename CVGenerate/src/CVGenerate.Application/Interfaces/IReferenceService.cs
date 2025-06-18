using CVGenerate.Core.DTOs.Reference;

namespace CVGenerate.Application.Interfaces;

public interface IReferenceService
{
    Task<List<ReferenceDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, ReferenceDto dto);
    Task DeleteAsync(Guid id);
}