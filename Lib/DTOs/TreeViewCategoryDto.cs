using Lib.Models;

namespace Lib.DTOs;

public class TreeViewCategoryDto : Category
{
    public List<TreeViewActivityDto> TreeViewActivities { get; set; } = new();
    public List<TreeViewJobDto> TreeViewJobs { get; set; } = new();
}