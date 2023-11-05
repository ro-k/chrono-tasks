namespace Lib.Models;

public class EventLog : LogEntry
{
    public Guid EventLogId { get; set; }
    public Guid EventId { get; set; }
}