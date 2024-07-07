using System.Diagnostics.CodeAnalysis;

namespace Lib.Models;

[ExcludeFromCodeCoverage]
public class MediaLog : LogEntry
{
    public Guid MediaLogId { get; set; }
    public Guid MediaId { get; set; }
}