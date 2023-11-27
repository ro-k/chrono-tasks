using Lib.DataAccess;
using Lib.Models;

namespace Lib.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryDataAccess _categoryDataAccess;
    private readonly IUserContext _userContext;

    public CategoryService(ICategoryDataAccess categoryDataAccess, IUserContext userContext)
    {
        _categoryDataAccess = categoryDataAccess;
        _userContext = userContext;
    }

    public async Task<Category> Create(string name, string description)
    {
        var category = new Category
        {
            CategoryId = Guid.NewGuid(),
            UserId = _userContext.UserId,
            Name = name,
            Description = description,
            Status = Status.Active,
        };
        return await Create(category);
    }
    
    public Task<Category> Create(Category model)
    {
        return _categoryDataAccess.Create(model);
    }

    public Task<Category> Update(Category model)
    {
        return _categoryDataAccess.Update(model);
    }

    public Task<List<Category>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return _categoryDataAccess.GetPaged(startRow, count, descending);
    }

    public Task<Category> Get(Guid id)
    {
        return _categoryDataAccess.Get(id);
    }

    public Task<IEnumerable<Category>> GetAllByUserContext()
    {
        return _categoryDataAccess.GetAllByUserContext();
    }
}