using Lib.Models;
using Lib.Services;
using Npgsql;

namespace Lib.DataAccess;

public class CategoryDataAccess : ICategoryDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IUserContext _userContext;

    public const string PagedCategoryCte = @"
WITH ranked_category_ids AS (
    SELECT category_id,
    ROW_NUMBER() OVER (ORDER BY created_at {0}) AS rn
    FROM public.category
)
WITH paged_category_ids AS (
    SELECT category_id
    FROM ranked_categories
    WHERE user_id = @UserId AND rn > @StartRow AND rn <= @EndRow
)
";

    public const string GetAllQuery = @"
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
    user_id = @UserId
ORDER BY created_at {0};
";

    public CategoryDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext)
    {
        _dataBaseManager = dataBaseManager;
        _userContext = userContext;
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

        return await _dataBaseManager.QuerySingleOrDefaultAsync<Category>(insertQuery, model);
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
            return await _dataBaseManager.QuerySingleOrDefaultAsync<Category>(query, parameters);
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
WHERE user_id = @UserId AND rn > @StartRow AND rn <= @EndRow;
";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { _userContext.UserId, StartRow = startRow, EndRow = startRow + count };

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

    public async Task<IEnumerable<Category>> GetAllByUserContext(bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        
        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(GetAllQuery, orderByDirection);
        
        var categories =  await _dataBaseManager.QueryAsync<Category>(finalQuery, new { _userContext.UserId });
        
        return categories;
    }

    public async Task<bool> Delete(Guid categoryId)
    {
        const string query = @"
DELETE FROM
    public.category
WHERE
    category_id = @CategoryId AND user_id = @UserId;";

        return await _dataBaseManager.ExecuteAsync(query, new { _userContext.UserId, categoryId }) > 0;
    }
}