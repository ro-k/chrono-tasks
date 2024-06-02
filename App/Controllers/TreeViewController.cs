using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TreeViewController(ITreeViewService treeViewService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var treeViewDto = await treeViewService.GetAllByUserContext();
        return Ok(treeViewDto);
    }
}