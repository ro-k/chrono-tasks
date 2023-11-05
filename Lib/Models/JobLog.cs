namespace Lib.Models;

public class JobLog : LogEntry
{
    public Guid JobLogId { get; set; }
    public Guid JobId { get; set; }
}