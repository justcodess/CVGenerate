using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Skill;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class SkillService : ISkillService
{
    private readonly IRepository<Skill> _repository;
    private readonly IMapper _mapper;

    public SkillService(IRepository<Skill> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<SkillDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<SkillDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, SkillDto dto)
    {
        var entity = _mapper.Map<Skill>(dto);
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