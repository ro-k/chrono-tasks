using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IUserContext _userContext;

    public CategoryController(ICategoryService categoryService, IUserContext userContext)
    {
        _categoryService = categoryService;
        _userContext = userContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        await _categoryService.Create($"Name_{Guid.NewGuid()}", $"Description_{Guid.NewGuid()}");   
        var categories = await _categoryService.GetAllByUserContext();
        return Ok(categories);
    }

    [HttpGet("{categoryId:guid}")]
    public async Task<IActionResult> Get(Guid categoryId)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await _categoryService.Get(categoryId));
    }

    [HttpDelete("{categoryId:guid}")]
    public async Task<IActionResult> Delete(Guid categoryId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
        _userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newCategory = await _categoryService.Create(category);

        return CreatedAtAction(nameof(Get), new { category.CategoryId }, newCategory);
    }
}