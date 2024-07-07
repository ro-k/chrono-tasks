using System.Diagnostics.CodeAnalysis;

namespace Lib.Models;


[ExcludeFromCodeCoverage]
public class Activity : BaseModel
{
    public Guid ActivityId { get; set; }
    
    public Guid? CategoryId { get; set; }
    
    public Guid? JobId { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}

public static class ActivityExtensions
{
    public static Activity UpdateWith(this Activity existing, Activity updated)
    {
        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.StartTime = updated.StartTime;
        existing.EndTime = updated.EndTime;
        return existing;
    }
}