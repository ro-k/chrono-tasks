using Lib.Models;

namespace Lib.DataAccess;

public interface IActivityDataAccess : IBaseDataAccess<Activity>
{
    public Task AssignCategory(Guid activityId, Guid categoryId, bool clearCurrentAssignments = true);
    public Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId);
    public Task ClearCategories(Guid activityId);
    
    public Task AssignJob(Guid activityId, Guid jobId, bool clearCurrentAssignments = true);
    public Task<IEnumerable<Activity>> GetAllByJob(Guid jobId);
    public Task ClearJobs(Guid activityId);
}