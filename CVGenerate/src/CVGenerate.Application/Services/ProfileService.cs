using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Profile;
using CVGenerate.Core.Entities;
using CVGenerate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CVGenerate.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileResponseDto> CreateAsync(ProfileCreateDto dto)
        {
            var profile = new Profile
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                Description = dto.Description,
                IsVisible = dto.IsVisible
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return new ProfileResponseDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Description = profile.Description
            };
        }

        public async Task<ProfileResponseDto> UpdateAsync(ProfileUpdateDto dto)
        {
            var profile = await _context.Profiles.FindAsync(dto.Id);
            if (profile == null) throw new Exception("Profile not found");

            profile.Description = dto.Description;
            await _context.SaveChangesAsync();

            return new ProfileResponseDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Description = profile.Description
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return false;

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProfileResponseDto?> GetByIdAsync(Guid id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return null;

            return new ProfileResponseDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Description = profile.Description
            };
        }

        public async Task<List<ProfileResponseDto>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Profiles
                .Where(p => p.UserId == userId)
                .Select(p => new ProfileResponseDto
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Description = p.Description
                })
                .ToListAsync();
        }
    }
}