using CVGenerate.Core.DTOs.Language;

namespace CVGenerate.Application.Interfaces;

public interface ILanguageService
{
    Task<List<LanguageDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, LanguageDto dto);
    Task DeleteAsync(Guid id);
}