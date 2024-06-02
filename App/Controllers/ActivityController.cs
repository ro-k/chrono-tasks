using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ActivityController(IActivityService activityService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(Activity activity)
    {
        var newActivity = await activityService.Create(activity.CategoryId, activity.JobId, activity.Name, activity.Description, activity.StartTime, activity.EndTime);

        return CreatedAtAction(nameof(Get), new { newActivity.ActivityId }, newActivity);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Activity activity)
    {
        var updatedActivity = await activityService.Update(activity);

        return Ok(updatedActivity);
    }

    [HttpGet("{activityId:guid}")]
    public async Task<IActionResult> Get(Guid activityId)
    {
        return Ok(await activityService.Get(activityId));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await activityService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}")]
    public async Task<IActionResult> Delete(Guid activityId)
    {
        if (await activityService.Delete(activityId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAllByCategory(Guid categoryId)
    {
        var categories = await activityService.GetAllByCategory(categoryId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/category/")]
    public async Task<IActionResult> ClearCategory(Guid activityId)
    {
        await activityService.ClearCategories(activityId);
        return NoContent();
    }
    
    [HttpGet("job/{jobId:guid}")]
    public async Task<IActionResult> GetAllByJob(Guid jobId)
    {
        var categories = await activityService.GetAllByJob(jobId);
        return Ok(categories);
    }
    
    [HttpDelete("{activityId:guid}/job/")]
    public async Task<IActionResult> ClearJob(Guid activityId)
    {
        await activityService.ClearJobs(activityId);
        return NoContent();
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetBy([FromQuery] Guid? categoryId, [FromQuery] Guid? jobId)
    // {
    //     var categories = await _activityService.GetByParent(categoryId, jobId);
    //     return Ok(categories);
    // }
    
    [HttpPut("{activityId:guid}")]
    public async Task<IActionResult> UpdateParents([FromRoute] Guid activityId, [FromQuery] Guid? categoryId, [FromQuery] Guid? jobId, [FromQuery] bool? clearCurrentAssignments)
    {
        await activityService.UpdateParents(activityId, categoryId, jobId, clearCurrentAssignments ?? true);
        return NoContent();
    }
}