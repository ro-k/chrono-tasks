using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

class IdentityService : IIdentityService
{
    public string HashPassword(User user, string password)
    {
        throw new NotImplementedException();
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
    {
        throw new NotImplementedException();
    }

    public string Normalize(string key)
    {
        throw new NotImplementedException();
    }
}