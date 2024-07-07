using System.Diagnostics.CodeAnalysis;

namespace Lib.Models;

[ExcludeFromCodeCoverage]
public class JobLog : LogEntry
{
    public Guid JobLogId { get; set; }
    public Guid JobId { get; set; }
}