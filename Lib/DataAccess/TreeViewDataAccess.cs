using Dapper;
using Lib.DTOs;
using Lib.Services;

namespace Lib.DataAccess;

public class TreeViewDataAccess : ITreeViewDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IUserContext _userContext;
    
    public TreeViewDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext)
    {
        _dataBaseManager = dataBaseManager;
        _userContext = userContext;
    }

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

        return await _dataBaseManager
            .QueryMultipleAsync(
                processGridReader, query, new { _userContext.UserId });
    }
}