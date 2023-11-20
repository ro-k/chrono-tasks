using Lib.DataAccess;
using Lib.Models;

namespace Lib.Services;

public class CategoryService
{
    private readonly ICategoryDataAccess _categoryDataAccess;

    public CategoryService(ICategoryDataAccess categoryDataAccess)
    {
        _categoryDataAccess = categoryDataAccess;
    }

    public async Task<Category> Create(string name, string description, Guid userId)
    {
        var category = new Category
        {
            CategoryId = Guid.NewGuid(),
            UserId = userId,
            Name = name,
            Description = description,
            Status = Status.Active,
        };
        return await _categoryDataAccess.Create(category);
    }

    public async Task<List<Category>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return await _categoryDataAccess.GetPaged(startRow, count, descending);
    }

    public async Task<Category> Get(Guid id)
    {
        return await _categoryDataAccess.Get(id);
    }
}