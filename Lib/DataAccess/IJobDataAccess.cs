using Lib.Models;

namespace Lib.DataAccess;

public interface IJobDataAccess : IBaseDataAccess<Job>
{
    public Task<IEnumerable<Job>> GetAllByCategoryId(Guid categoryId, bool descending = true);
}