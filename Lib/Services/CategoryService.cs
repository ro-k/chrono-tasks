using Lib.DataAccess;
using Lib.Exceptions;
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
        model.UserId = _userContext.UserId;
        
        return _categoryDataAccess.Create(model);
    }

    public async Task<Category> Update(Category model)
    {
        var current = await Get(model.CategoryId);
        if (model.ConcurrencyStamp != current.ConcurrencyStamp)
        {
            throw new ConcurrencyStampMismatchException();
        }
        current.UpdateWith(model);
        return await _categoryDataAccess.Update(current);
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

    public Task<bool> Delete(Guid categoryId)
    {
        return _categoryDataAccess.Delete(categoryId);
    }
}