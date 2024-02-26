using Lib.Models;

namespace Lib.DataAccess;

public interface IActivityDataAccess
{
    Task<Activity> Create(Activity model);
    Task<Activity> Update(Activity model);
    Task<List<Activity>> GetPaged(int startRow = 0, int count = 100, bool descending = true);
    Task<Activity> Get(Guid id);
    Task<IEnumerable<Activity>> GetAllByUserContext(bool descending = true);
    Task<bool> Delete(Guid activityId);
    Task AssignCategory(Guid activityId, Guid? categoryId, bool clearCurrentAssignments = true);
    Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId);
    Task ClearCategories(Guid activityId);
    Task AssignJob(Guid activityId, Guid? jobId, bool clearCurrentAssignments = true);
    Task<IEnumerable<Activity>> GetAllByJob(Guid jobId);
    Task ClearJobs(Guid activityId);
}