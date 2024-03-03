using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;
    private readonly IUserContext _userContext;

    public ActivityController(IActivityService activityService, IUserContext userContext)
    {
        _activityService = activityService;
        _userContext = userContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Activity activity)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newActivity = await _activityService.Create(activity.Name, activity.Description, activity.StartTime, activity.EndTime);

        return CreatedAtAction(nameof(Get), new { newActivity.ActivityId }, newActivity);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Activity activity)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var updatedActivity = await _activityService.Update(activity);

        return Ok(updatedActivity);
    }

    [HttpGet("{activityId:guid}")]
    public async Task<IActionResult> Get(Guid activityId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await _activityService.Get(activityId));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await _activityService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}")]
    public async Task<IActionResult> Delete(Guid activityId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        if (await _activityService.Delete(activityId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAllByCategory(Guid categoryId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        var categories = await _activityService.GetAllByCategory(categoryId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/category/")]
    public async Task<IActionResult> ClearCategory(Guid activityId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await _activityService.ClearCategories(activityId);
        return NoContent();
    }
    
    [HttpGet("job/{jobId:guid}")]
    public async Task<IActionResult> GetAllByJob(Guid jobId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        var categories = await _activityService.GetAllByJob(jobId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/job/")]
    public async Task<IActionResult> ClearJob(Guid activityId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await _activityService.ClearJobs(activityId);
        return NoContent();
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetBy([FromQuery] Guid? categoryId, [FromQuery] Guid? jobId)
    // {
    //     _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
    //
    //     var categories = await _activityService.GetByParent(categoryId, jobId);
    //     return Ok(categories);
    // }
    
    [HttpPut("{activityId:guid}")]
    public async Task<IActionResult> UpdateParents([FromRoute] Guid activityId, [FromQuery] Guid? categoryId, [FromQuery] Guid? jobId, [FromQuery] bool? clearCurrentAssignments)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await _activityService.UpdateParents(activityId, categoryId, jobId, clearCurrentAssignments ?? true);
        return NoContent();
    }
}