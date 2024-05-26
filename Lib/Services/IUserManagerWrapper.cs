using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public interface IUserManagerWrapper
{
    /// <summary>
    /// Creates the specified <paramref name="user" /> in the backing store with given password,
    /// as an asynchronous operation.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <param name="password">The password for the user to hash and store.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" />
    /// of the operation.
    /// </returns>
    Task<IdentityResult> CreateAsync(User user, string password);

    /// <summary>
    /// Add the specified <paramref name="user" /> to the named role.
    /// </summary>
    /// <param name="user">The user to add to the named role.</param>
    /// <param name="role">The name of the role to add the user to.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" />
    /// of the operation.
    /// </returns>
    Task<IdentityResult> AddToRoleAsync(User user, string role);
}