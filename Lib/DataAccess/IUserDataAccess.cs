using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.DataAccess;

public interface IUserDataAccess : //IUserStore<User>,
    IUserPasswordStore<User>,
    IUserRoleStore<User>, 
    IUserEmailStore<User>,
    IUserLockoutStore<User>, 
    IUserPhoneNumberStore<User>,
    IUserSecurityStampStore<User>,
    IUserLoginStore<User>
{
    Task<User> FindByUserNameOrThrowAsync(User user, CancellationToken ct);
    Task<User> FindByEmailOrThrowAsync(User user, CancellationToken ct);
}