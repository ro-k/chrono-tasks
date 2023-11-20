using Lib.DataAccess;
using Lib.Models;

namespace Lib.Services;

public class JobService
{
    private readonly IJobDataAccess _jobDataAccess;

    public JobService(IJobDataAccess jobDataAccess)
    {
        _jobDataAccess = jobDataAccess;
    }

    public async Task<Job> Create(string name, string description, Guid userId)
    {
        var job = new Job
        {
            JobId = Guid.NewGuid(),
            UserId = userId,
            Name = name,
            Description = description,
            Status = Status.Active,
        };
        return await _jobDataAccess.Create(job);
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