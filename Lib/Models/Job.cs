namespace Lib.Models;

public class Job : BaseModel
{
    public Guid JobId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Data { get; set; } //json blob
}