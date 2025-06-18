using CVGenerate.Core.DTOs.WebLink;

namespace CVGenerate.Application.Interfaces;

public interface IWebLinkService
{
    Task<List<WebLinkDto>> GetByUserIdAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId, WebLinkDto dto);
    Task DeleteAsync(Guid id);
}