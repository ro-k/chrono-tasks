using Dapper;
using Lib.DTOs;

namespace Lib.DataAccess;

public interface ITreeViewDataAccess
{
    Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>
        GetAllByUserContext(
            Func<SqlMapper.GridReader,
                Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>> processGridReader,
            bool descending = true);
}