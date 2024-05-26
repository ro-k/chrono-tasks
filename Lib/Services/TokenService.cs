using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lib.DataAccess;
using Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lib.Services;

public class TokenService(IOptions<AppSettings> appSettings, IUserDataAccess userDataAccess) : ITokenService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public string GenerateJwtToken(User user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

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

    public async Task<string> RefreshToken(string expiredToken)
    {
        var principal = GetPrincipalFromExpiredToken(expiredToken, appSettings.Value.JwtKey!);
        
        if (principal.Identity?.Name == null) throw new SecurityTokenException("Invalid claims principal");
        
        var username = principal.Identity.Name;
        var user = await userDataAccess.FindByUserNameOrThrowAsync(username, new CancellationToken());
        var newToken = GenerateJwtToken(user, await userDataAccess.GetRolesAsync(user, new CancellationToken()));
        return newToken;
    }

    private static ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string jwtKey)
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

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}