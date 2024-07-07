using System.Diagnostics.CodeAnalysis;

namespace Lib.Models;

[ExcludeFromCodeCoverage]
public class ActivityLog : LogEntry
{
    public Guid ActivityLogId { get; set; }
    public Guid ActivityId { get; set; }
}