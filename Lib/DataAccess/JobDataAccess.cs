using Lib.Models;
using Lib.Services;
using Npgsql;

namespace Lib.DataAccess;

public class JobDataAccess : IJobDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IUserContext _userContext;

    public const string GetAllQuery = @"
SELECT
    job_id,
    category_id,
    name,
    description,
    data,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.job
WHERE
    user_id = @UserId
ORDER BY created_at {0};
";

    public JobDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext)
    {
        _dataBaseManager = dataBaseManager;
        _userContext = userContext;
    }

    public async Task<Job> Create(Job model)
    {
        const string insertQuery = @"
INSERT INTO public.job (
    job_id, 
    category_id, 
    name, 
    description,
    data, 
    created_at, 
    modified_at, 
    user_id, 
    concurrency_stamp,
    status  
) VALUES (
    @JobId, 
    @CategoryId, 
    @Name, 
    @Description,
    @Data, 
    @CreatedAt, 
    @ModifiedAt, 
    @UserId, 
    @ConcurrencyStamp,
    @Status
)
RETURNING *;";

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Job>(insertQuery, model);
    }

    public async Task<Job> Update(Job model)
    {
        const string updateQuery = @"
UPDATE public.job SET
    category_id = @CategoryId,
    name = @Name,
    description = @Description,
    data = @Data,
    created_at = @CreatedAt,
    modified_at = @ModifiedAt,
    user_id = @UserId,
    concurrency_stamp = @ConcurrencyStamp,
    status = @Status
WHERE job_id = @JobId";

        var (query, parameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, model);

        try
        {
            return await _dataBaseManager.QuerySingleOrDefaultAsync<Job>(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            throw;
        }
    }

    public async Task<List<Job>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";

        const string pagedQuery = @"
WITH ranked_jobs AS (
    SELECT *,
    ROW_NUMBER() OVER (ORDER BY created_at {0}) AS rn
    FROM public.job
)
SELECT
    job_id,
    category_id,
    name,
    description,
    data,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM ranked_jobs
WHERE rn > @StartRow AND rn <= @EndRow;
";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { StartRow = startRow, EndRow = startRow + count };

        return (await _dataBaseManager.QueryAsync<Job>(finalQuery, parameters)).ToList();
    }

    public async Task<Job> Get(Guid jobId)
    {
        const string query = @"
SELECT
    job_id,
    category_id,
    name,
    description,
    data,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.job
WHERE
    job_id = @JobId;";

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Job>(query, new { JobId = jobId });
    }

    public async Task<IEnumerable<Job>> GetAllByUserContext(bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        
        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(GetAllQuery, orderByDirection);

        return await _dataBaseManager.QueryAsync<Job>(finalQuery, new { _userContext.UserId });
    }

    public async Task<bool> Delete(Guid jobId)
    {
        const string query = @"
DELETE FROM
    public.job
WHERE
    job_id = @JobId AND user_id = @UserId;";

        return await _dataBaseManager.ExecuteAsync(query, new { _userContext.UserId, jobId }) > 0;
    }

    public async Task<IEnumerable<Job>> GetAllByCategoryId(Guid categoryId, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        const string getByCategoryQuery = @"
SELECT
    job_id,
    category_id,
    name,
    description,
    data,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.job
WHERE
    user_id = @UserId
    category_id = @CategoryId  
ORDER BY created_at {0};
";
        
        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(getByCategoryQuery, orderByDirection);

        return await _dataBaseManager.QueryAsync<Job>(finalQuery, new { _userContext.UserId, categoryId });
    }
}