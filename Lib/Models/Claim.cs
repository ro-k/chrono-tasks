namespace Lib.Models;

public class Claim
{
    public Guid ClaimId { get; set; }
    public Guid RoleId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
}