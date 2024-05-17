using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController(IActivityService activityService, IUserContext userContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(Activity activity)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newActivity = await activityService.Create(activity.CategoryId, activity.JobId, activity.Name, activity.Description, activity.StartTime, activity.EndTime);

        return CreatedAtAction(nameof(Get), new { newActivity.ActivityId }, newActivity);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Activity activity)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var updatedActivity = await activityService.Update(activity);

        return Ok(updatedActivity);
    }

    [HttpGet("{activityId:guid}")]
    public async Task<IActionResult> Get(Guid activityId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await activityService.Get(activityId));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await activityService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}")]
    public async Task<IActionResult> Delete(Guid activityId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        if (await activityService.Delete(activityId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAllByCategory(Guid categoryId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        var categories = await activityService.GetAllByCategory(categoryId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/category/")]
    public async Task<IActionResult> ClearCategory(Guid activityId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await activityService.ClearCategories(activityId);
        return NoContent();
    }
    
    [HttpGet("job/{jobId:guid}")]
    public async Task<IActionResult> GetAllByJob(Guid jobId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        var categories = await activityService.GetAllByJob(jobId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/job/")]
    public async Task<IActionResult> ClearJob(Guid activityId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await activityService.ClearJobs(activityId);
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
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp

        await activityService.UpdateParents(activityId, categoryId, jobId, clearCurrentAssignments ?? true);
        return NoContent();
    }
}