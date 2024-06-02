using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await categoryService.GetAllByUserContext();
        return Ok(categories);
    }

    [HttpGet("{categoryId:guid}")]
    public async Task<IActionResult> Get(Guid categoryId)
    {
        return Ok(await categoryService.Get(categoryId));
    }

    [HttpDelete("{categoryId:guid}")]
    public async Task<IActionResult> Delete(Guid categoryId)
    {
        if (await categoryService.Delete(categoryId))
        {
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
        var newCategory = await categoryService.Create(category.Name, category.Description);

        return CreatedAtAction(nameof(Get), new { category.CategoryId }, newCategory);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Category category)
    {
        var updatedCategory = await categoryService.Update(category);

        return Ok(updatedCategory);
    }
}