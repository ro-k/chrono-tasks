using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeViewController : ControllerBase
{
    private readonly ITreeViewService _treeViewService;
    private readonly IUserContext _userContext;

    public TreeViewController(ITreeViewService treeViewService, IUserContext userContext)
    {
        _treeViewService = treeViewService;
        _userContext = userContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var treeViewDto = await _treeViewService.GetAllByUserContext();
        return Ok(treeViewDto);
    }
}