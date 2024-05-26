using System.Security.Authentication;
using Lib.DataAccess;
using Lib.DTOs;
using Lib.Models;

namespace Lib.Services;

public class UserService(
    ISignInManagerWrapper signInManager,
    IUserManagerWrapper userManager,
    IUserDataAccess userDataAccess,
    ITokenService tokenService)
    : IUserService
{
    public async Task<string> Login(LoginDto loginDto)
    {
        var result = await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, lockoutOnFailure: false);
        
        if (!result.Succeeded) throw new AuthenticationException();
        
        var cancellationToken = new CancellationToken();
        var user = await userDataAccess.FindByUserNameOrThrowAsync(loginDto.Username, cancellationToken);
        var roles = await userDataAccess.GetRolesAsync(user, cancellationToken);
        var token = tokenService.GenerateJwtToken(user, roles.ToList());
        
        return token;
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }

    public async Task Register(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);
    
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "DefaultRole");
            await signInManager.SignInAsync(user, isPersistent: false);
        }

        // Handle errors if necessary
        // e.g., throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public Task ExternalLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
}