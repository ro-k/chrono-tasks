using Lib.Models;
using Npgsql;

namespace Lib.DataAccess;

public class JobDataAccess : IJobDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;

    public JobDataAccess(IDataBaseManager dataBaseManager)
    {
        _dataBaseManager = dataBaseManager;
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

        return await _dataBaseManager.ExecuteScalarAsync<Job>(insertQuery, model);
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
            return await _dataBaseManager.ExecuteScalarAsync<Job>(query, parameters);
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
WHERE rn > @StartRow AND rn <= @EndRow
ORDER BY created_at {0};";

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
}