using System.Diagnostics.CodeAnalysis;

namespace Lib.Models;

[ExcludeFromCodeCoverage]
public class Category : BaseModel
{
    public Guid CategoryId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}

public static class CategoryExtensions
{
    public static Category UpdateWith(this Category existing, Category updated)
    {
        existing.Name = updated.Name;
        existing.Description = updated.Description;
        return existing;
    }
}