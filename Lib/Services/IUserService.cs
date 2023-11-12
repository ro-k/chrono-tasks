
namespace Lib.Services;

public interface IUserService
{
    public Task<string> Login(string user, string secret);
}