using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;

namespace Lib.Services;

public class JobService : IJobService
{
    private readonly IJobDataAccess _jobDataAccess;
    private readonly IUserContext _userContext;

    public JobService(IJobDataAccess jobDataAccess, IUserContext userContext)
    {
        _jobDataAccess = jobDataAccess;
        _userContext = userContext;
    }

    public async Task<Job> Create(Guid categoryId, string name, string description, string data)
    {
        var job = new Job
        {
            JobId = Guid.NewGuid(),
            CategoryId = categoryId,
            UserId = _userContext.UserId,
            Name = name,
            Description = description,
            Status = Status.Active,
            Data = data,
        };
        return await _jobDataAccess.Create(job);
    }
    
    public Task<Job> Create(Job model)
    {
        model.UserId = _userContext.UserId;
        model.JobId = Guid.NewGuid();
        
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

    public async Task<IEnumerable<Job>> GetByCategoryId(Guid categoryId)
    {
        return await _jobDataAccess.GetByCategoryId(categoryId);
    }

    public async Task<Job> Update(Job model)
    {
        var current = await Get(model.JobId);
        if (model.ConcurrencyStamp != current.ConcurrencyStamp)
        {
            throw new ConcurrencyStampMismatchException();
        }
        current.UpdateWith(model);
        return await _jobDataAccess.Update(current);
    }
    
    public Task<IEnumerable<Job>> GetAllByUserContext()
    {
        return _jobDataAccess.GetAllByUserContext();
    }

    public Task<bool> Delete(Guid jobId)
    {
        return _jobDataAccess.Delete(jobId);
    }
}