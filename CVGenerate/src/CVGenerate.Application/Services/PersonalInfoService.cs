using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.PersonalInfo;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;

namespace CVGenerate.Application.Services;

public class PersonalInfoService : IPersonalInfoService
{
    private readonly IRepository<PersonalInfo> _repository;
    private readonly IMapper _mapper;

    public PersonalInfoService(IRepository<PersonalInfo> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PersonalInfoDto?> GetByUserIdAsync(Guid userId)
    {
        var all = await _repository.GetAllAsync();
        var entity = all.FirstOrDefault(x => x.UserId == userId);
        return entity is null ? null : _mapper.Map<PersonalInfoDto>(entity);
    }

    public async Task<Guid> UpsertAsync(Guid userId, PersonalInfoDto dto)
    {
        var all = await _repository.GetAllAsync();
        var entity = all.FirstOrDefault(x => x.UserId == userId);

        if (entity is null)
        {
            var newEntity = _mapper.Map<PersonalInfo>(dto);
            newEntity.Id = Guid.NewGuid();
            newEntity.UserId = userId;
            await _repository.AddAsync(newEntity);
            return newEntity.Id;
        }

        _mapper.Map(dto, entity);
        _repository.Update(entity);
        return entity.Id;
    }

    public async Task DeleteAsync(Guid userId)
    {
        var all = await _repository.GetAllAsync();
        var entity = all.FirstOrDefault(x => x.UserId == userId);
        if (entity is not null)
            _repository.Delete(entity);
    }
}