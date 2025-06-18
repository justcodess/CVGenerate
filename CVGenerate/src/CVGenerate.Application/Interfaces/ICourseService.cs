using CVGenerate.Core.DTOs.Course;

namespace CVGenerate.Application.Interfaces;

public interface ICourseService
{
    Task<List<CourseDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, CourseDto dto);
    Task DeleteAsync(Guid id);
}