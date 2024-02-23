using Lib.Models;

namespace Lib.Services;

public interface IJobService
{
    Task<Job> Create(Guid categoryId, string name, string description, string data);
    Task<Job> Create(Job model);
    Task<List<Job>> GetPaged(int startRow = 0, int count = 100, bool descending = true);
    Task<Job> Get(Guid id);
    Task<IEnumerable<Job>> GetAllByCategoryId(Guid categoryId);
    Task<Job> Update(Job model);
    Task<IEnumerable<Job>> GetAllByUserContext();
    Task<bool> Delete(Guid jobId);
}