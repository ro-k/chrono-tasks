using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IJobService jobService, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await jobService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAllByCategoryId(Guid categoryId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        
        var categories = await jobService.GetAllByCategoryId(categoryId);
        return Ok(categories);
    }

    [HttpGet("{jobId:guid}")]
    public async Task<IActionResult> Get(Guid jobId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await jobService.Get(jobId));
    }

    [HttpDelete("{jobId:guid}")]
    public async Task<IActionResult> Delete(Guid jobId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        if (await jobService.Delete(jobId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Job job)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newJob = await jobService.Create(job.CategoryId, job.Name, job.Description, job.Data);

        return CreatedAtAction(nameof(Get), new { newJob.JobId }, newJob);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Job job)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var updatedJob = await jobService.Update(job);

        return Ok(updatedJob);
    }
}