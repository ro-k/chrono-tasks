using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;

namespace Lib.Services;

public class JobService(IJobDataAccess jobDataAccess, IUserContext userContext) : IJobService
{
    public async Task<Job> Create(Guid categoryId, string name, string description, string data)
    {
        var job = new Job
        {
            JobId = Guid.NewGuid(),
            CategoryId = categoryId,
            UserId = userContext.UserId,
            Name = name,
            Description = description,
            Status = Status.Active,
            Data = data,
        };
        return await jobDataAccess.Create(job);
    }
    
    public async Task<Job> Create(Job model)
    {
        model.UserId = userContext.UserId;
        model.JobId = Guid.NewGuid();
        
        return await jobDataAccess.Create(model);
    }

    public async Task<List<Job>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return await jobDataAccess.GetPaged(startRow, count, descending);
    }

    public async Task<Job> Get(Guid id)
    {
        return await jobDataAccess.Get(id);
    }

    public async Task<IEnumerable<Job>> GetAllByCategoryId(Guid categoryId)
    {
        return await jobDataAccess.GetAllByCategoryId(categoryId);
    }

    public async Task<Job> Update(Job model)
    {
        var current = await Get(model.JobId);
        if (model.ConcurrencyStamp != current.ConcurrencyStamp)
        {
            throw new ConcurrencyStampMismatchException();
        }
        current.UpdateWith(model);
        return await jobDataAccess.Update(current);
    }
    
    public async Task<IEnumerable<Job>> GetAllByUserContext()
    {
        return await jobDataAccess.GetAllByUserContext();
    }

    public async Task<bool> Delete(Guid jobId)
    {
        return await jobDataAccess.Delete(jobId);
    }
}