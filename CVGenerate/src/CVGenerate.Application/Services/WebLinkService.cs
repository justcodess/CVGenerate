using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.WebLink;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class WebLinkService : IWebLinkService
{
    private readonly IRepository<WebLink> _repository;
    private readonly IMapper _mapper;

    public WebLinkService(IRepository<WebLink> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<WebLinkDto>> GetByUserIdAsync(Guid userId)
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<List<WebLinkDto>>(data.Where(x => x.UserId == userId));
    }

    public async Task<Guid> AddAsync(Guid userId, WebLinkDto dto)
    {
        var entity = _mapper.Map<WebLink>(dto);
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