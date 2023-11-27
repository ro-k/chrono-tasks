using Lib.Models;

namespace Lib.Services;

public interface ICategoryService
{
    Task<Category> Create(string name, string description);
    Task<Category> Create(Category model);
    Task<Category> Update(Category model);
    Task<List<Category>> GetPaged(int startRow = 0, int count = 100, bool descending = true);
    Task<Category> Get(Guid id);
    Task<IEnumerable<Category>> GetAllByUserContext();
}