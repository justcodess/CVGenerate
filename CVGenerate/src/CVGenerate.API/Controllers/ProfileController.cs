using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CVGenerate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var profiles = await _profileService.GetByUserIdAsync(Guid.Parse(userId));
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            if (profile == null) return NotFound();

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            dto.UserId = Guid.Parse(userId);

            var result = await _profileService.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProfileUpdateDto dto)
        {
            var result = await _profileService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _profileService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}