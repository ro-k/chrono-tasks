using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public class AuthService : IAuthService
{
    private readonly ISignInManagerWrapper _signInManager;

    public AuthService(ISignInManagerWrapper signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<string> Login(string user, string password)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(user, password, true, false);

        throw new NotImplementedException();
    }

    public async Task Logout(string user)
    {
        throw new NotImplementedException();
    }

    public async Task Register()
    {
        throw new NotImplementedException();
    }

    public async Task ExternalLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateToken()
    {
        throw new NotImplementedException();
    }

    public async Task<string> RefreshToken()
    {
        throw new NotImplementedException();
    }
}