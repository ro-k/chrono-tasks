namespace Lib.Models;

public class BaseModel : IHasConcurrencyStamp
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public Guid ConcurrencyStamp { get; set; } = Guid.NewGuid();
}