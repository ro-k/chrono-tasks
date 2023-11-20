namespace Lib.Models;

public class Activity : BaseModel
{
    public Guid ActivityId { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}