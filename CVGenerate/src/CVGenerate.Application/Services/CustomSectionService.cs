using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.CustomSection;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class CustomSectionService : ICustomSectionService
{
    private readonly IRepository<CustomSection> _repository;
    private readonly IMapper _mapper;

    public CustomSectionService(IRepository<CustomSection> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CustomSectionDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<CustomSectionDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, CustomSectionDto dto)
    {
        var entity = _mapper.Map<CustomSection>(dto);
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