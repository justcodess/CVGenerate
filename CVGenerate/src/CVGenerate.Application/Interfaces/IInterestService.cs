using CVGenerate.Core.DTOs.Interest;

namespace CVGenerate.Application.Interfaces;

public interface IInterestService
{
    Task<List<InterestDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, InterestDto dto);
    Task DeleteAsync(Guid id);
}