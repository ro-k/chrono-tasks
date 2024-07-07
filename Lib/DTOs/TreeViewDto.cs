using System.Diagnostics.CodeAnalysis;

namespace Lib.DTOs;

[ExcludeFromCodeCoverage]
public class TreeViewDto
{
    public List<TreeViewCategoryDto> Categories { get; set; } = [];
}