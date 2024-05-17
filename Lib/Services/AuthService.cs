using Lib.DataAccess;
using Lib.DTOs;
using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public class AuthService : IAuthService
{
    private readonly ISignInManagerWrapper _signInManager;
    private readonly IUserDataAccess _userDataAccess;
    private readonly ITokenService _tokenService;

    public AuthService(ISignInManagerWrapper signInManager, IUserDataAccess userDataAccess, ITokenService tokenService)
    {
        _signInManager = signInManager;
        _userDataAccess = userDataAccess;
        _tokenService = tokenService;
    }

    public async Task<string> Login(LoginDto login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, lockoutOnFailure: false);
        
        // todo: add custom exceptions
        if (!result.Succeeded) throw new Exception("Unauthorized");
        
        
        var cancellationToken = new CancellationToken();
        var user = await _userDataAccess.FindByNameAsync(login.Username, cancellationToken);
        var roles = await _userDataAccess.GetRolesAsync(user, cancellationToken);
        var token = _tokenService.GenerateJwtToken(user, roles.ToList());
        return token;
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