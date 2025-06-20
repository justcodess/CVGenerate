using CVGenerate.Application.Interfaces;
using CVGenerate.Core.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CVGenerate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        if (!result.Success)
            return Unauthorized(result.Message);

        return Ok(result);
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (userId == null)
            return Unauthorized();

        return Ok(new
        {
            UserId = userId,
            Email = email
        });
    }
}