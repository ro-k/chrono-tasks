using Lib.Models;

namespace Lib.Services;

public interface ITokenService
{
    string GenerateJwtToken(User user, IEnumerable<string> roles);
}