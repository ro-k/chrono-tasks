using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public interface ISignInManagerWrapper
{
    /// <summary>
    /// Attempts to sign in the specified <paramref name="userName"/> and <paramref name="password"/> combination
    /// as an asynchronous operation.
    /// </summary>
    /// <param name="userName">The user name to sign in.</param>
    /// <param name="password">The password to attempt to sign in with.</param>
    /// <param name="isPersistent">Flag indicating whether the sign-in cookie should persist after the browser is closed.</param>
    /// <param name="lockoutOnFailure">Flag indicating if the user account should be locked if the sign in fails.</param>
    /// <returns>The task object representing the asynchronous operation containing the <see name="SignInResult"/>
    /// for the sign-in attempt.</returns>
    public Task<SignInResult> PasswordSignInAsync(string userName, string password,
        bool isPersistent, bool lockoutOnFailure);
    
    
}