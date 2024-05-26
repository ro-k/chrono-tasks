using Lib.DTOs;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        return Ok(await userService.Login(login));
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        await userService.Register(registerDto);
        return Ok();
    }
    
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await userService.Logout();
        return Ok();
    }
}