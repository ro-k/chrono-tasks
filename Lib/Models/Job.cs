namespace Lib.Models;

public class Job : BaseModel
{
    public Guid JobId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Data { get; set; } //json blob
}

public static class JobExtensions
{
    public static Job UpdateWith(this Job existing, Job updated)
    {
        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.Data = updated.Data;
        return existing;
    }
}