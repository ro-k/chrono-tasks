using System.Security.Claims;
using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public class SignInManagerWrapper(SignInManager<User> signInManager) : ISignInManagerWrapper
{
    public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return await signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
    }

    public async Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null)
    {
        await signInManager.SignInAsync(user, isPersistent, authenticationMethod);
    }

    public async Task SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }

    public bool IsSignedIn(ClaimsPrincipal user)
    {
        return signInManager.IsSignedIn(user);
    }

    public async Task RefreshSignInAsync(User user)
    {
        await signInManager.RefreshSignInAsync(user);
    }

    public async Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
    {
        return await signInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);
    }
}