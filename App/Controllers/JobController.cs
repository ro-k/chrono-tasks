using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IUserContext _userContext;

    public JobController(IJobService jobService, IUserContext userContext)
    {
        _jobService = jobService;
        _userContext = userContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await _jobService.GetAllByUserContext();
        return Ok(categories);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByCategoryId([FromQuery] Guid categoryId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await _jobService.GetAllByCategoryId(categoryId);
        return Ok(categories);
    }

    [HttpGet("{jobId:guid}")]
    public async Task<IActionResult> Get(Guid jobId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await _jobService.Get(jobId));
    }

    [HttpDelete("{jobId:guid}")]
    public async Task<IActionResult> Delete(Guid jobId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        if (await _jobService.Delete(jobId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Job job)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newJob = await _jobService.Create(job.CategoryId, job.Name, job.Description, job.Data);

        return CreatedAtAction(nameof(Get), new { newJob.JobId }, newJob);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Job job)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var updatedJob = await _jobService.Update(job);

        return Ok(updatedJob);
    }
}