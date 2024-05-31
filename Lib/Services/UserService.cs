using Lib.DataAccess;
using Lib.DTOs;
using Lib.Exceptions;
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
        // switch to using username, email not required
        // go through model, mark nullable fields as nullable?
        var result = await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, lockoutOnFailure: false);
        
        if (!result.Succeeded) throw new InvalidLoginException();
        
        var cancellationToken = new CancellationToken();
        var user = await userDataAccess.FindByUserNameOrThrowAsync(new User { Username = loginDto.Username },
            cancellationToken);
        var roles = await userDataAccess.GetRolesAsync(user, cancellationToken);
        var token = tokenService.GenerateJwtToken(user, roles.ToList());
        
        return token;
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }

    public async Task<string> Register(RegisterDto registerDto)
    {
        var user = new User
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);
    
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "DefaultRole");
            //await signInManager.SignInAsync(user, isPersistent: false);
            return await Login(new() { Username = registerDto.Username, Password = registerDto.Password });
        }

        throw new BadRequestException(result.Errors.Select(e => e.Description));
    }

    public Task ExternalLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
}