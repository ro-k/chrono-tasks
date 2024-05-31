
using Lib.DTOs;

namespace Lib.Services;

public interface IUserService
{
    Task<string> Login(LoginDto loginDto);
    public Task Logout();
    public Task<string> Register(RegisterDto registerDto);
    public Task ExternalLogin(string loginProvider, string providerKey);
}