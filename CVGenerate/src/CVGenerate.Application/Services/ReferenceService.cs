using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Reference;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class ReferenceService : IReferenceService
{
    private readonly IRepository<Reference> _repository;
    private readonly IMapper _mapper;

    public ReferenceService(IRepository<Reference> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ReferenceDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<ReferenceDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, ReferenceDto dto)
    {
        var entity = _mapper.Map<Reference>(dto);
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