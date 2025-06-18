using CVGenerate.Core.Entities;

namespace CVGenerate.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}