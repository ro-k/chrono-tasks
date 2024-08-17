using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;

namespace Lib.Services;

public class ActivityService(IActivityDataAccess activityDataAccess) : IActivityService
{
    public async Task<Activity> Create(Guid? categoryId, Guid? jobId, string name, string description, DateTime startTime, DateTime endTime)
    {
        var activity = new Activity
        {
            ActivityId = Guid.NewGuid(),
            CategoryId = categoryId,
            JobId = jobId,
            Name = name,
            Description = description,
            StartTime = startTime.ToUniversalTime(),
            EndTime = endTime.ToUniversalTime(),
            Status = Status.Active,
        };
        return await activityDataAccess.Create(activity);
    }
    
    public async Task<Activity> Update(Activity model)
    {
        var current = await Get(model.ActivityId);
        if (model.ConcurrencyStamp != current.ConcurrencyStamp)
        {
            throw new ConcurrencyStampMismatchException();
        }
        current.UpdateWith(model);
        return await activityDataAccess.Update(current);
    }

    public async Task<List<Activity>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return await activityDataAccess.GetPaged(startRow, count, descending);
    }

    public async Task<Activity> Get(Guid id)
    {
        return await activityDataAccess.Get(id);
    }
    
    public async Task<IEnumerable<Activity>> GetAllByUserContext()
    {
        return await activityDataAccess.GetAllByUserContext();
    }

    public async Task<bool> Delete(Guid activityId)
    {
        return await activityDataAccess.Delete(activityId);
    }

    public async Task AssignCategory(Guid activityId, Guid categoryId, bool clearCurrentAssignments = true)
    {
        await activityDataAccess.AssignCategory(activityId, categoryId, clearCurrentAssignments);
    }

    public async Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId)
    {
        return await activityDataAccess.GetAllByCategory(categoryId);
    }

    public async Task ClearCategories(Guid activityId)
    {
        await activityDataAccess.ClearCategories(activityId);
    }

    public async Task AssignJob(Guid activityId, Guid jobId, bool clearCurrentAssignments = true)
    {
        await activityDataAccess.AssignJob(activityId, jobId, clearCurrentAssignments);
    }

    public async Task<IEnumerable<Activity>> GetAllByJob(Guid jobId)
    {
        return await activityDataAccess.GetAllByJob(jobId);
    }
    
    public async Task ClearJobs(Guid activityId)
    {
        await activityDataAccess.ClearJobs(activityId);
    }

    /// <summary>
    /// Combined method for getting activities by either parent entity.
    /// Category activities are returned if both ids are provided
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Activity>> GetByParent(Guid? categoryId, Guid? jobId)
    {
        if (categoryId.HasValue)
        {
            return await GetAllByCategory(categoryId.Value);
        }

        if (jobId.HasValue)
        {
            return await GetAllByJob(jobId.Value);
        }
            
        return Enumerable.Empty<Activity>();
    }

    public async Task UpdateParents(Guid activityId, Guid? categoryId, Guid? jobId, bool clearCurrentAssignments = true)
    {
        if (!categoryId.HasValue && !jobId.HasValue)
        {
            await ClearCategories(activityId);
            await ClearJobs(activityId);
            return;
        }
        
        if (categoryId.HasValue)
        {
            await AssignCategory(activityId, categoryId.Value, clearCurrentAssignments);
        }

        if (jobId.HasValue)
        {
            await AssignJob(activityId, jobId.Value, clearCurrentAssignments);
        }
    }
}