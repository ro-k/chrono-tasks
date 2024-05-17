
using Microsoft.AspNetCore.Identity;

namespace Lib.Services;

public interface IAuthService
{
    public Task<SignInResult> Login(string user, string password);
    public Task Logout(string user);
    public Task Register();
    public Task ExternalLogin(string loginProvider, string providerKey);
    public Task<string> CreateToken();
    public Task<string> RefreshToken();
}