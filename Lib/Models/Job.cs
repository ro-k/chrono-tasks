namespace Lib.Models;

public class Job
{
    public Guid JobId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    public string Data { get; set; } //json blob
    
}