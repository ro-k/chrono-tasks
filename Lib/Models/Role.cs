
namespace Lib.Models;

public class Role : IHasConcurrencyStamp
{
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
    public Guid ConcurrencyStamp { get; set; } = Guid.NewGuid();
    public List<Claim>? Claims { get; set; }
}