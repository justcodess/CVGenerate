using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Profile;
using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;
using Profile = CVGenerate.Core.Entities.Profile;


namespace CVGenerate.Application.Services;

public class ProfileService : IProfileService
{
    private readonly IRepository<Profile> _repository;
    private readonly IMapper _mapper;

    public ProfileService(IRepository<Profile> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProfileDto?> GetByUserIdAsync(Guid userId)
    {
        var all = await _repository.GetAllAsync();
        var entity = all.FirstOrDefault(x => x.UserId == userId);
        return entity is null ? null : _mapper.Map<ProfileDto>(entity);
    }

    public async Task<Guid> UpsertAsync(Guid userId, ProfileDto dto)
    {
        var all = await _repository.GetAllAsync();
        var entity = all.FirstOrDefault(x => x.UserId == userId);

        if (entity is null)
        {
            var newEntity = _mapper.Map<Profile>(dto);
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