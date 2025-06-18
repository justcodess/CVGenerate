using CVGenerate.Core.DTOs.Skill;

namespace CVGenerate.Application.Interfaces;

public interface ISkillService
{
    Task<List<SkillDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, SkillDto dto);
    Task DeleteAsync(Guid id);
}