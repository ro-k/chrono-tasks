using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lib.DataAccess;
using Lib.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lib.Services;

public class TokenService(IOptions<AppSettings> appSettings, IUserDataAccess userDataAccess) : ITokenService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public string GenerateJwtToken(User user, IEnumerable<string> roles)
    {
        var claims = GetClaims(user);

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _appSettings.JwtIssuer,
            Audience = _appSettings.JwtAudience,
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static List<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Username),
        };

        if (!string.IsNullOrEmpty(user.Email))
        {
            claims.Add(new(JwtRegisteredClaimNames.Email, user.Email));
        }
        if (!string.IsNullOrEmpty(user.FirstName))
        {
            claims.Add(new(JwtRegisteredClaimNames.GivenName, user.FirstName));
        }
        if (!string.IsNullOrEmpty(user.LastName))
        {
            claims.Add(new(JwtRegisteredClaimNames.FamilyName, user.LastName));
        }

        return claims;
    }

    public async Task<(bool, string)> TryRefreshToken(string expiredToken)
    {
        var (principal, jwtToken) = GetPrincipalFromExpiredToken(expiredToken, appSettings.Value.JwtKey!);
        
        if (jwtToken.ValidTo > DateTime.UtcNow.AddMinutes(5))
        {
            return (false, string.Empty);
        }

        // todo: swap to userId?
        var username = principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
        
        if (string.IsNullOrEmpty(username)) throw new SecurityTokenException("Invalid claims");
        
        //var username = principal.Identity.Name;
        var user = await userDataAccess.FindByUserNameOrThrowAsync(new User { Username = username }, new CancellationToken());

        return (true, GenerateJwtToken(user, await userDataAccess.GetRolesAsync(user, new CancellationToken())));
    }

    private static (ClaimsPrincipal, JwtSecurityToken) GetPrincipalFromExpiredToken(string token, string jwtKey)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateLifetime = false // ignore token's expiration date
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is JwtSecurityToken jwtSecurityToken &&
            jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            return (principal, jwtSecurityToken);
        }
        
        throw new SecurityTokenException("Invalid token");

    }
}