namespace Lib.Models;

public class Category : BaseModel
{
    public Guid CategoryId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}