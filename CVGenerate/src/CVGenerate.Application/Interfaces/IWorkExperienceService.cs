using CVGenerate.Core.DTOs.WorkExperience;

namespace CVGenerate.Application.Interfaces;

public interface IWorkExperienceService
{
    Task<List<WorkExperienceDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, WorkExperienceDto dto);
    Task DeleteAsync(Guid id);
}