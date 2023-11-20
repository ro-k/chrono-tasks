using Lib.Models;
using Npgsql;

namespace Lib.DataAccess;

public class CategoryDataAccess : ICategoryDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;

    public CategoryDataAccess(IDataBaseManager dataBaseManager)
    {
        _dataBaseManager = dataBaseManager;
    }

    public async Task<Category> Create(Category model)
    {
        const string insertQuery = @"
INSERT INTO public.category (
    category_id, 
    name, 
    description, 
    created_at, 
    modified_at, 
    user_id, 
    concurrency_stamp,
    status
) VALUES (
    @CategoryId, 
    @Name, 
    @Description, 
    @CreatedAt, 
    @ModifiedAt, 
    @UserId, 
    @ConcurrencyStamp,
    @Status
)
RETURNING *;";

        return await _dataBaseManager.ExecuteScalarAsync<Category>(insertQuery, model);
    }

    public async Task<Category> Update(Category model)
    {
        const string updateQuery = @"
UPDATE public.category SET
    name = @Name,
    description = @Description,
    created_at = @CreatedAt,
    modified_at = @ModifiedAt,
    user_id = @UserId,
    concurrency_stamp = @ConcurrencyStamp,
    status = @Status
WHERE category_id = @CategoryId";

        var (query, parameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, model);

        try
        {
            return await _dataBaseManager.ExecuteScalarAsync<Category>(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            throw;
        }
    }
    
    public async Task<List<Category>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";

        const string pagedQuery = @"
WITH ranked_categories AS (
    SELECT *,
    ROW_NUMBER() OVER (ORDER BY created_at {0}) AS rn
    FROM public.category
)
SELECT
    category_id,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM ranked_categories
WHERE rn > @StartRow AND rn <= @EndRow
ORDER BY created_at {0};";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { StartRow = startRow, EndRow = startRow + count };

        return (await _dataBaseManager.QueryAsync<Category>(finalQuery, parameters)).ToList();
    }
    
    public async Task<Category> Get(Guid categoryId)
    {
        const string query = @"
SELECT
    category_id,
    name,
    description,
    created_at,
    modified_at,
    user_id,
    concurrency_stamp,
    status
FROM
    public.category
WHERE
    category_id = @CategoryId;";

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Category>(query, new { CategoryId = categoryId });
    }
}