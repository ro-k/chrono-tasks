using Lib.Models;
using Lib.Services;
using Npgsql;

namespace Lib.DataAccess;

public class ActivityDataAccess : IActivityDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IUserContext _userContext;
    
    public const string GetAllQuery = @"
SELECT
    activity.activity_id,
    start_time,
    end_time,
    category_id,
    job_id,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM public.activity
WHERE user_id = @UserId
ORDER BY created_at {0};
";
    
    public ActivityDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext)
    {
        _dataBaseManager = dataBaseManager;
        _userContext = userContext;
    }

    public async Task<Activity> Create(Activity model)
    {
        const string insertQuery = @"
INSERT INTO public.activity (
    activity_id, 
    category_id,
    job_id,
    start_time, 
    end_time, 
    name, 
    description, 
    created_at, 
    modified_at, 
    user_id, 
    concurrency_stamp,
    status
) VALUES (
    @ActivityId,
    @CategoryId,
    @JobId,
    @StartTime, 
    @EndTime, 
    @Name, 
    @Description, 
    @CreatedAt, 
    @ModifiedAt, 
    @UserId, 
    @ConcurrencyStamp,
    @Status
)
RETURNING *;";

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Activity>(insertQuery, new {
            model.ActivityId,
            model.CategoryId,
            model.JobId,
            model.StartTime,
            model.EndTime,
            model.Name,
            model.Description,
            model.CreatedAt,
            model.ModifiedAt,
            _userContext.UserId,
            model.ConcurrencyStamp,
            model.Status
        });
    }

    public async Task<Activity> Update(Activity model)
    {
        const string updateQuery = @"
UPDATE public.activity SET
    category_id = @CategoryId,
    job_id = @JobId,
    start_time = @StartTime,
    end_time = @EndTime,
    name = @Name,
    description = @Description,
    modified_at = @ModifiedAt,
    user_id = @UserId,
    concurrency_stamp = @ConcurrencyStamp,
    status = @Status
WHERE activity_id = @ActivityId";

        model.UserId = _userContext.UserId;
        
        var (query, parameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, model);

        try
        {
            return await _dataBaseManager.QuerySingleOrDefaultAsync<Activity>(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            
            throw;
        }
    }


    public async Task<List<Activity>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";

        const string pagedQuery = @"
WITH ranked_activities AS (
    SELECT *,
    ROW_NUMBER() OVER (ORDER BY created_at {0}) AS rn
    FROM public.activity
)
SELECT
    activity_id,
    category_id,
    job_id,
    start_time,
    end_time,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM ranked_activities
WHERE rn > @StartRow AND rn <= @EndRow AND user_id = @UserId;
";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { StartRow = startRow, EndRow = startRow + count, _userContext.UserId };

        return (await _dataBaseManager.QueryAsync<Activity>(finalQuery, parameters)).ToList();
    }

    public async Task<Activity> Get(Guid id)
    {
        const string query = @"
SELECT
    activity_id,
    category_id,
    job_id,
    start_time,
    end_time,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.activity
WHERE
    activity_id = @Id and user_id = @UserId;";

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Activity>(query, new { Id = id, _userContext.UserId });
    }

    public async Task<IEnumerable<Activity>> GetAllByUserContext(bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        const string query = @"
SELECT
    activity_id,
    category_id,
    job_id,
    start_time,
    end_time,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.activity
WHERE
    user_id = @UserId
ORDER BY created_at {0};
";
        
        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(query, orderByDirection);

        return await _dataBaseManager.QueryAsync<Activity>(finalQuery, new { _userContext.UserId });
    }

    public async Task<bool> Delete(Guid activityId)
    {
        const string query = @"
DELETE FROM
    public.activity
WHERE
    activity_id = @ActivityId AND user_id = @UserId;";

        return await _dataBaseManager.ExecuteAsync(query, new { _userContext.UserId, activityId }) > 0;
    }

    public async Task AssignCategory(Guid activityId, Guid? categoryId, bool clearCurrentAssignments = true)
    {
        const string insertQuery = @"
update public.activity set ({0}) 
where user_id = @UserId and activity_id = @ActivityId;
";
        var query = string.Format(insertQuery,
            clearCurrentAssignments ? "categoryId = @CategoryId, jobId = @JobId" : "categoryId = @CategoryId");

        await _dataBaseManager.ExecuteAsync(query, clearCurrentAssignments
            ? new { categoryId, activityId, _userContext.UserId, JobId = (object)null! }
            : new { categoryId, activityId, _userContext.UserId }
        );
    }

    public async Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId)
    {
        const string query = @"
SELECT
    activity_id,
    category_id,
    job_id,
    start_time,
    end_time,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.activity
WHERE
    category_id = @CategoryId and user_id = @UserId;
";

        return await _dataBaseManager.QueryAsync<Activity>(query, new { categoryId, _userContext.UserId });
    }

    public async Task ClearCategories(Guid activityId)
    {
        await AssignCategory(activityId, null, false);
    }

    public async Task AssignJob(Guid activityId, Guid? jobId, bool clearCurrentAssignments = true)
    {
        const string insertQuery = @"
update public.activity set ({0}) 
where user_id = @UserId and activity_id = @ActivityId;
";
        var query = string.Format(insertQuery,
            clearCurrentAssignments ? "jobId = @JobId, categoryId = @CategoryId" : "jobId = @JobId");

        await _dataBaseManager.ExecuteAsync(query, clearCurrentAssignments
            ? new { jobId, activityId, _userContext.UserId, CategoryId = (object)null! }
            : new { jobId, activityId, _userContext.UserId }
        );
    }

    public async Task<IEnumerable<Activity>> GetAllByJob(Guid jobId)
    {
        const string query = @"
SELECT
    activity_id,
    category_id,
    job_id,
    start_time,
    end_time,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.activity
WHERE
    job_id = @JobId and user_id = @UserId;";

        return await _dataBaseManager.QueryAsync<Activity>(query, new { jobId, _userContext.UserId });
    }

    public async Task ClearJobs(Guid activityId)
    {
        await AssignJob(activityId, null, false);
    }
}