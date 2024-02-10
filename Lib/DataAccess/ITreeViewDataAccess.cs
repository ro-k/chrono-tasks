using Dapper;
using Lib.DTOs;
using Lib.Models;

namespace Lib.DataAccess;

public interface ITreeViewDataAccess
{
    Task<(IEnumerable<Category>, IEnumerable<Job>, IEnumerable<TreeViewActivityDto>)> GetAllByUserContext(
        Func<SqlMapper.GridReader, Task<(IEnumerable<Category>, IEnumerable<Job>, IEnumerable<TreeViewActivityDto>)>>
            processGridReader, bool descending = true);
}