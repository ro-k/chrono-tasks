using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public interface IIdentityService : IPasswordHasher<User>, IUserValidator<User>, IPasswordValidator<User>,
    ILookupNormalizer
{
}