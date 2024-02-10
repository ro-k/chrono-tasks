using Lib.Models;

namespace Lib.DTOs;

public class TreeViewJobDto : Job
{
    public List<TreeViewActivityDto> TreeViewActivities { get; set; } = new();
}