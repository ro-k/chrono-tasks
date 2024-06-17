using Lib.DTOs;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        return Ok(new { access_token = await userService.Login(login) });
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(RegisterDto registerDto)
    {
        return Ok(new { access_token = await userService.Register(registerDto) });
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await userService.Logout();
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await userService.GetUser());
    }
}