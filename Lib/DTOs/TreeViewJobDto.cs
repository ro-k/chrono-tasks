using System.Diagnostics.CodeAnalysis;
using Lib.Models;

namespace Lib.DTOs;

[ExcludeFromCodeCoverage]
public class TreeViewJobDto : Job
{
    public List<TreeViewActivityDto> TreeViewActivities { get; set; } = new();
}