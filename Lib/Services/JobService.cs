using Lib.DataAccess;
using Lib.Models;

namespace Lib.Services;

public class JobService
{
    private readonly IJobDataAccess _jobDataAccess;
    private readonly IUserContext _userContext;

    public JobService(IJobDataAccess jobDataAccess, IUserContext userContext)
    {
        _jobDataAccess = jobDataAccess;
        _userContext = userContext;
    }

    public async Task<Job> Create(Guid categoryId, string name, string description)
    {
        var job = new Job
        {
            JobId = Guid.NewGuid(),
            CategoryId = categoryId,
            UserId = _userContext.UserId,
            Name = name,
            Description = description,
            Status = Status.Active,
        };
        return await _jobDataAccess.Create(job);
    }
    
    public Task<Job> Create(Job model)
    {
        model.UserId = _userContext.UserId;
        
        return _jobDataAccess.Create(model);
    }

    public async Task<List<Job>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return await _jobDataAccess.GetPaged(startRow, count, descending);
    }

    public async Task<Job> Get(Guid id)
    {
        return await _jobDataAccess.Get(id);
    }
}