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
}