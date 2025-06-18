using CVGenerate.Core.DTOs.Education;

namespace CVGenerate.Application.Interfaces;

public interface IEducationService
{
    Task<List<EducationDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, EducationDto dto);
    Task DeleteAsync(Guid id);
}