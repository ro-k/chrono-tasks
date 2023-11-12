using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public class UserService : IUserService
{
    private readonly SignInManager<User> _signInManager;

    public UserService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<string> Login(string user, string secret)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(user, secret, true, false);
        
        
        throw new NotImplementedException();
    }
}