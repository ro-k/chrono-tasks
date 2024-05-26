using System.Security.Claims;
using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public interface ISignInManagerWrapper
{
    /// <summary>
    /// Attempts to sign in a user with the specified username and password.
    /// </summary>
    /// <param name="userName">The user's username.</param>
    /// <param name="password">The user's password.</param>
    /// <param name="isPersistent">True to persist authentication across sessions; otherwise, false.</param>
    /// <param name="lockoutOnFailure">True to lock the user out after too many failed login attempts; otherwise, false.</param>
    /// <returns>The result of the sign-in attempt.</returns>
    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

    /// <summary>
    /// Signs in the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user to sign-in.</param>
    /// <param name="isPersistent">Flag indicating whether the sign-in cookie should persist after the browser is closed.</param>
    /// <param name="authenticationMethod">Name of the method used to authenticate the user.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null);

    /// <summary>
    /// Signs the user out of the application.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SignOutAsync();

    /// <summary>
    /// Checks if the specified ClaimsPrincipal is signed in.
    /// </summary>
    /// <param name="user">The ClaimsPrincipal to check for authentication.</param>
    /// <returns>True if the user is signed in; otherwise, false.</returns>
    bool IsSignedIn(ClaimsPrincipal user);

    /// <summary>
    /// Refreshes the sign-in cookies for the specified user.
    /// </summary>
    /// <param name="user">The user whose sign-in cookies should be refreshed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RefreshSignInAsync(User user);

    /// <summary>
    /// Attempts to sign in a user via two-factor authentication.
    /// </summary>
    /// <param name="provider">The two-factor authentication provider used to verify the user.</param>
    /// <param name="code">The two-factor authentication code provided by the user.</param>
    /// <param name="isPersistent">True to persist authentication across sessions; otherwise, false.</param>
    /// <param name="rememberClient">True to remember the client on the device being used.</param>
    /// <returns>The result of the two-factor sign-in attempt.</returns>
    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);


}