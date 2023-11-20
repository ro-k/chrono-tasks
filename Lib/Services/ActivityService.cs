using Lib.DataAccess;
using Lib.Models;

namespace Lib.Services;

public class ActivityService
{
    private readonly IActivityDataAccess _activityDataAccess;

    public ActivityService(IActivityDataAccess activityDataAccess)
    {
        _activityDataAccess = activityDataAccess;
    }

    public async Task<Activity> Create(string name, string description, DateTime startTime, DateTime endTime, Guid userId)
    {
        var activity = new Activity
        {
            ActivityId = Guid.NewGuid(),
            UserId = userId,
            Name = name,
            Description = description,
            StartTime = startTime.ToUniversalTime(),
            EndTime = endTime.ToUniversalTime(),
            Status = Status.Active,
        };
        return await _activityDataAccess.Create(activity);
    }

    public async Task<List<Activity>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return await _activityDataAccess.GetPaged(startRow, count, descending);
    }

    public async Task<Activity> Get(Guid id)
    {
        return await _activityDataAccess.Get(id);
    }
}