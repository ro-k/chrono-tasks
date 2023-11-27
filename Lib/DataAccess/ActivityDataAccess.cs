using Lib.Models;
using Lib.Services;
using Npgsql;

namespace Lib.DataAccess;

public class ActivityDataAccess : IActivityDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IUserContext _userContext;
    
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
returning *;";

        return await _dataBaseManager.ExecuteScalarAsync<Activity>(insertQuery, new {
            model.ActivityId,
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
            return await _dataBaseManager.ExecuteScalarAsync<Activity>(query, parameters);
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
WHERE rn > @StartRow AND rn <= @EndRow AND user_id = @UserId
ORDER BY created_at {0};";

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

    public async Task<IEnumerable<Activity>> GetAllByUserContext()
    {
        const string query = @"
SELECT
    activity_id,
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
    user_id = @UserId;
";

        return await _dataBaseManager.QueryAsync<Activity>(query, new { _userContext.UserId });
    }

    public async Task AssignCategory(Guid activityId, Guid categoryId, bool clearCurrentAssignments = true)
    {
        const string deleteQuery = @"
delete from public.category_activity 
where activity_id = @ActivityId and activity_id in 
    (select activity_id from public.activity where user_id = @UserId);
";
        
        const string insertQuery = @"
insert into public.category_activity (category_id, activity_id) 
select a.activity_id, c.category_id from activity a
join category c on a.user_id = c.user_id
where a.user_id = @UserId and a.activity_id = @ActivityId and c.category_id = @CategoryId;
";

        await _dataBaseManager.ExecuteAsync(clearCurrentAssignments ? $"{deleteQuery}{insertQuery}"
                : insertQuery,
            new { categoryId, activityId, _userContext.UserId });
    }

    public async Task<IEnumerable<Activity>> GetAllByCategory(Guid categoryId)
    {
        const string query = @"
SELECT
    a.activity_id,
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
    public.activity a
JOIN
    public.category_activity ca on a.activity_id = ca.activity_id
WHERE
    ca.category_id = @CategoryId and a.user_id = @UserId;
";

        return await _dataBaseManager.QueryAsync<Activity>(query, new { categoryId, _userContext.UserId });
    }

    public async Task ClearCategories(Guid activityId)
    {
        const string deleteQuery = @"
delete from public.category_activity where activity_id = @ActivityId
and activity_id in (select activity_id from public.activity where user_id = @UserId);
";

        await _dataBaseManager.ExecuteAsync(deleteQuery, new { activityId, _userContext.UserId });
    }

    public async Task AssignJob(Guid activityId, Guid jobId, bool clearCurrentAssignments = true)
    {
        const string deleteQuery = @"
delete from public.job_activity 
where activity_id = @ActivityId and activity_id in 
    (select activity_id from public.activity where user_id = @UserId);
";
        
        const string insertQuery = @"
insert into public.job_activity (job_id, activity_id) 
select a.activity_id, j.job_id from activity a
join job j on a.user_id = j.user_id
where a.user_id = @UserId and a.activity_id = @ActivityId and j.job_id = @JobId;
";
        await _dataBaseManager.ExecuteAsync(clearCurrentAssignments ? $"{deleteQuery}{insertQuery}"
                : insertQuery,
            new { jobId, activityId, _userContext.UserId });
    }

    public async Task<IEnumerable<Activity>> GetAllByJob(Guid jobId)
    {
        const string query = @"
SELECT
    a.activity_id,
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
    public.activity a
JOIN
    public.job_activity ja on a.activity_id = ja.activity_id
WHERE
    ja.job_id = @JobId and a.user_id = @UserId;";

        return await _dataBaseManager.QueryAsync<Activity>(query, new { jobId, _userContext.UserId });
    }

    public async Task ClearJobs(Guid activityId)
    {
        const string deleteQuery = @"
delete from public.job_activity where activity_id = @ActivityId
and activity_id in (select activity_id from public.activity where user_id = @UserId);
";

        await _dataBaseManager.ExecuteAsync(deleteQuery, new { activityId, _userContext.UserId });
    }
}