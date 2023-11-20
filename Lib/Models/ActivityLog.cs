namespace Lib.Models;

public class ActivityLog : LogEntry
{
    public Guid ActivityLogId { get; set; }
    public Guid ActivityId { get; set; }
}