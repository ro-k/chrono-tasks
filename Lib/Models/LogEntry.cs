using Lib.Models;

public class LogEntry : BaseModel
{
    public Guid LogEntryId { get; set; }
    public DateTime LoggedAt { get; set; }
    public string Message { get; set; }
    public string Data { get; set; }
}