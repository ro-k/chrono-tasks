using Lib.Models;

namespace Lib.DTOs;

public class TreeViewActivityDto : Activity
{
    public Guid? CategoryId { get; set; }
    public Guid? JobId { get; set; }
}