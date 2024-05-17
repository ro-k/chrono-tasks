
using Lib.DTOs;

namespace Lib.Services;

public interface IAuthService
{
    Task<string> Login(LoginDto login);
    public Task Logout(string user);
    public Task Register();
    public Task ExternalLogin(string loginProvider, string providerKey);
    public Task<string> CreateToken();
    public Task<string> RefreshToken();
}