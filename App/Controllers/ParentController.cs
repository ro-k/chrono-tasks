using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ParentController(IParentService parentService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var parentIds = await parentService.GetAllByUserContext();
        return Ok(parentIds);
    }
}