using Lib.Models;

namespace Lib.Services;

public interface IActivityService
{
    Task<Activity> Create(Guid? categoryId, Guid? jobId, string name, string description, DateTime startTime, DateTime endTime);
    Task<Activity> Update(Activity model);
    Task<List<Activity>> GetPaged(int startRow = 0, int count = 100, bool descending = true);
    Task<Activity> Get(Guid id);
    Task<IEnumerable<Activity>> GetAllByUserContext();
    Task<bool> Delete(Guid activityId);
    Task AssignCategory(Guid activityId, Guid categoryId, bool clearCurrentAssignments = true);
    Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId);
    Task ClearCategories(Guid activityId);
    Task AssignJob(Guid activityId, Guid jobId, bool clearCurrentAssignments = true);
    Task<IEnumerable<Activity>> GetAllByJob(Guid jobId);
    Task ClearJobs(Guid activityId);
    Task<IEnumerable<Activity>> GetByParent(Guid? categoryId, Guid? jobId);
    Task UpdateParents(Guid activityId, Guid? categoryId, Guid? jobId, bool clearCurrentAssignments = true);
}