using Lib.DTOs;
using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        return Ok(await authService.Login(login));
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        throw new NotImplementedException();
        //return Ok(await authService.Login(login));
    }
}