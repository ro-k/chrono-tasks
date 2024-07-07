using System.Diagnostics.CodeAnalysis;
using Lib.Models;

namespace Lib.DTOs;

// todo: reduce info in jwt claims
[ExcludeFromCodeCoverage]
public class UserDto
{
    public Guid UserId { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public Guid? ProfilePictureMediaId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public Guid ConcurrencyStamp { get; set; } = Guid.NewGuid();
    public Status Status { get; set; } = Status.Active;

    public static UserDto FromUser(User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            TwoFactorEnabled = user.TwoFactorEnabled,
            ProfilePictureMediaId = user.ProfilePictureMediaId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt,
            ModifiedAt = user.ModifiedAt,
            ConcurrencyStamp = user.ConcurrencyStamp,
            Status = user.Status
        };
    }
}