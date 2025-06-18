using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.WorkExperience;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class WorkExperienceService : IWorkExperienceService
{
    private readonly IRepository<WorkExperience> _repository;
    private readonly IMapper _mapper;

    public WorkExperienceService(IRepository<WorkExperience> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<WorkExperienceDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<WorkExperienceDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, WorkExperienceDto dto)
    {
        var entity = _mapper.Map<WorkExperience>(dto);
        entity.UserId = userId;
        entity.Id = Guid.NewGuid();
        await _repository.AddAsync(entity);
        return entity.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is not null)
            _repository.Delete(entity);
    }
}