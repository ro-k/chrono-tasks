using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.DataAccess;

public interface IUserDataAccess : IUserPasswordStore<User>, IUserRoleStore<User>, IUserEmailStore<User>, IUserLockoutStore<User>, IUserPhoneNumberStore<User>, IUserSecurityStampStore<User>, IUserLoginStore<User>
{
    
}