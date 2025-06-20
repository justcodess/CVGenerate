using CVGenerate.Core.Entities;
using CVGenerate.Core.Interfaces;
using CVGenerate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CVGenerate.Infrastructure.Repositories;

public class EfUserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public EfUserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> IsEmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}