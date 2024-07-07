using System.Diagnostics.CodeAnalysis;
using Lib.Models;

namespace Lib.DTOs;

[ExcludeFromCodeCoverage]
public class TreeViewCategoryDto : Category
{
    public List<TreeViewActivityDto> TreeViewActivities { get; set; } = new();
    public List<TreeViewJobDto> TreeViewJobs { get; set; } = new();
}