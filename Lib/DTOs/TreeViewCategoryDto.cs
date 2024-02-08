using Lib.Models;

namespace Lib.DTOs;

public class TreeViewCategoryDto : Category
{
    public List<TreeViewActivityDto> TreeViewActivities { get; set; }
    public List<TreeViewJobDto> TreeViewJobs { get; set; }
}