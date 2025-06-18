using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Language;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class LanguageService : ILanguageService
{
    private readonly IRepository<Language> _repository;
    private readonly IMapper _mapper;

    public LanguageService(IRepository<Language> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<LanguageDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<LanguageDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, LanguageDto dto)
    {
        var entity = _mapper.Map<Language>(dto);
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