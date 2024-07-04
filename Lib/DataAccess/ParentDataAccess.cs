using Lib.Services;

namespace Lib.DataAccess;

public class ParentDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext) : IParentDataAccess
{
    public async Task<IEnumerable<Guid>> GetAllByUserContext()
    {
        const string query = @"
SELECT activity_id FROM public.media WHERE user_id = @UserId
UNION
SELECT category_id FROM public.activity WHERE user_id = @UserId AND category_id IS NOT NULL
UNION
SELECT job_id FROM public.activity WHERE user_id = @UserId AND job_id IS NOT NULL
UNION
SELECT category_id FROM public.job WHERE user_id = @UserId
";
        
        return await dataBaseManager.QueryAsync<Guid>(query, new { userContext.UserId });
    }
}


