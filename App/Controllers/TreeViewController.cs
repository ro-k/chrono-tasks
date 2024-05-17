using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeViewController(ITreeViewService treeViewService, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var treeViewDto = await treeViewService.GetAllByUserContext();
        return Ok(treeViewDto);
    }
}