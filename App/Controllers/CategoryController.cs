using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var categories = await categoryService.GetAllByUserContext();
        return Ok(categories);
    }

    [HttpGet("{categoryId:guid}")]
    public async Task<IActionResult> Get(Guid categoryId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        return Ok(await categoryService.Get(categoryId));
    }

    [HttpDelete("{categoryId:guid}")]
    public async Task<IActionResult> Delete(Guid categoryId)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        if (await categoryService.Delete(categoryId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var newCategory = await categoryService.Create(category.Name, category.Description);

        return CreatedAtAction(nameof(Get), new { category.CategoryId }, newCategory);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Category category)
    {
        userContext.UserId = Guid.Parse("27bf9e8e-317c-4a71-a2a3-61fa0be6d40a"); // TODO: temp
        var updatedCategory = await categoryService.Update(category);

        return Ok(updatedCategory);
    }
}