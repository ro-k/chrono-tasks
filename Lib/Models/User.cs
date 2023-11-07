namespace Lib.Models;

public class User : IHasConcurrencyStamp
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = string.Empty;
    public string NormalizedUserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NormalizedEmail { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string SecurityStamp { get; set; } = string.Empty;
    public Guid ConcurrencyStamp { get; set; } = Guid.NewGuid();
    public string PhoneNumber { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public Guid? ProfilePictureMediaId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public Status Status { get; set; }
    // For Claims and Roles, consider using separate classes and linking via foreign keys.
    // public ICollection<Claim> Claims { get; set; }
    // public ICollection<Role> Roles { get; set; }
}