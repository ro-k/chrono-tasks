using Lib.Models;

public class LogEntry : BaseModel
{
    public Guid LogEntryId { get; set; }
    public DateTime LoggedAt { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
}