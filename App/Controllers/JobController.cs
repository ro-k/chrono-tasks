using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobController(IJobService jobService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await jobService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAllByCategoryId(Guid categoryId)
    {
        var categories = await jobService.GetAllByCategoryId(categoryId);
        return Ok(categories);
    }

    [HttpGet("{jobId:guid}")]
    public async Task<IActionResult> Get(Guid jobId)
    {
        return Ok(await jobService.Get(jobId));
    }

    [HttpDelete("{jobId:guid}")]
    public async Task<IActionResult> Delete(Guid jobId)
    {
        if (await jobService.Delete(jobId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Job job)
    {
        var newJob = await jobService.Create(job.CategoryId, job.Name, job.Description, job.Data);

        return CreatedAtAction(nameof(Get), new { newJob.JobId }, newJob);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Job job)
    {
        var updatedJob = await jobService.Update(job);

        return Ok(updatedJob);
    }
}