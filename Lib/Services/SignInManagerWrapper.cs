using System.Security.Claims;
using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public class SignInManagerWrapper : ISignInManagerWrapper
{
    private readonly SignInManager<User> _signInManager;

    public SignInManagerWrapper(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public bool IsSignedIn(ClaimsPrincipal user)
    {
        return _signInManager.IsSignedIn(user);
    }

    public async Task RefreshSignInAsync(User user)
    {
        await _signInManager.RefreshSignInAsync(user);
    }

    public async Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
    {
        return await _signInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);
    }
}