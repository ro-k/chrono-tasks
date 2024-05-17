using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;

namespace Lib.Services;

public class CategoryService(ICategoryDataAccess categoryDataAccess, IUserContext userContext)
    : ICategoryService
{
    public async Task<Category> Create(string name, string description)
    {
        var category = new Category
        {
            CategoryId = Guid.NewGuid(),
            UserId = userContext.UserId,
            Name = name,
            Description = description,
            Status = Status.Active,
        };
        return await Create(category);
    }
    
    public Task<Category> Create(Category model)
    {
        model.UserId = userContext.UserId;
        model.CategoryId = Guid.NewGuid();
        
        return categoryDataAccess.Create(model);
    }

    public async Task<Category> Update(Category model)
    {
        var current = await Get(model.CategoryId);
        if (model.ConcurrencyStamp != current.ConcurrencyStamp)
        {
            throw new ConcurrencyStampMismatchException();
        }
        current.UpdateWith(model);
        return await categoryDataAccess.Update(current);
    }

    public Task<List<Category>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        return categoryDataAccess.GetPaged(startRow, count, descending);
    }

    public Task<Category> Get(Guid id)
    {
        return categoryDataAccess.Get(id);
    }

    public Task<IEnumerable<Category>> GetAllByUserContext()
    {
        return categoryDataAccess.GetAllByUserContext();
    }

    public Task<bool> Delete(Guid categoryId)
    {
        return categoryDataAccess.Delete(categoryId);
    }
}