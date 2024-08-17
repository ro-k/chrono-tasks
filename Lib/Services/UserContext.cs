using System.Diagnostics.CodeAnalysis;

namespace Lib.Services;

[ExcludeFromCodeCoverage]
public class UserContext : IUserContext
{
    public Guid UserId { get; set; }
}