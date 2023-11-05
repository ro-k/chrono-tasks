namespace Lib.Models;

public class MediaLog : LogEntry
{
    public Guid MediaLogId { get; set; }
    public Guid MediaId { get; set; }
}