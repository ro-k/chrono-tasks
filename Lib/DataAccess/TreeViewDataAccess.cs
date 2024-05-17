using Dapper;
using Lib.DTOs;
using Lib.Services;

namespace Lib.DataAccess;

public class TreeViewDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext) : ITreeViewDataAccess
{
    public async Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>
        GetAllByUserContext(
            Func<SqlMapper.GridReader,
                Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>> processGridReader,
            bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        var query = @"
{0}
{1}
{2}
";
        // put Category, Jobs and Activity queries together
        query = string.Format(query, CategoryDataAccess.GetAllQuery, JobDataAccess.GetAllQuery,
            ActivityDataAccess.GetAllQuery);

        // replace order by
        query = string.Format(query, orderByDirection);

        return await dataBaseManager
            .QueryMultipleAsync(
                processGridReader, query, new { userContext.UserId });
    }
}