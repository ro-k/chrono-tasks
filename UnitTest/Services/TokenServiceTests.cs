using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using Lib;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.Services;

public class TokenServiceTests
{
    private readonly Mock<IUserDataAccess> _userDataAccessMock;
    private readonly ITokenService _tokenService;
    private readonly AppSettings _appSettings;
    private readonly UserFaker _userFaker = new();

    public TokenServiceTests()
    {
        _userDataAccessMock = new Mock<IUserDataAccess>();

        _appSettings = new AppSettings
        {
            JwtKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), // 512 bit
            JwtIssuer = "unit_test_issuer",
            JwtAudience = "unit_test_audience"
        };

        var appSettingsOptions = Options.Create(_appSettings);
        _tokenService = new TokenService(appSettingsOptions, _userDataAccessMock.Object);
    }
    
    [Fact]
    public void GenerateJwtToken_ShouldReturnToken_WhenUserIsValid()
    {
        // Given
        var user = _userFaker.Generate();

        var roles = new List<string> { "Admin", "User" };

        // When
        var token = _tokenService.GenerateJwtToken(user, roles);

        // Then
        token.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task TryRefreshToken_ShouldReturnNewToken_WhenTokenIsValid()
    {
        // Given
        var user = _userFaker.Generate();

        var roles = new List<string> { "Admin", "User" };

        _userDataAccessMock.Setup(uda => uda.FindByUserNameOrThrowAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _userDataAccessMock.Setup(uda => uda.GetRolesAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(roles);

        _tokenService.GenerateJwtToken(user, roles);

        // Simulate an expired token
        var expiredToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: _appSettings.JwtIssuer,
            audience: _appSettings.JwtAudience,
            claims: new List<Claim>
            {
                new(ClaimTypes.Name, user.Username)
            },
            expires: DateTime.UtcNow.AddMinutes(-1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey!)),
                SecurityAlgorithms.HmacSha256)
        ));

        // When
        var (isSuccessful, newToken) = await _tokenService.TryRefreshToken(expiredToken);

        // Then
        isSuccessful.Should().BeTrue();
        newToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task TryRefreshToken_ShouldReturnFalse_WhenTokenIsNotExpiredEnough()
    {
        // Given
        var user = _userFaker.Generate();

        var roles = new List<string> { "Admin", "User" };

        _userDataAccessMock.Setup(uda => uda.FindByUserNameOrThrowAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _userDataAccessMock.Setup(uda => uda.GetRolesAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(roles);

        _tokenService.GenerateJwtToken(user, roles);

        // Simulate a recently expired token (less than 5 minutes)
        var recentlyExpiredToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: _appSettings.JwtIssuer,
            audience: _appSettings.JwtAudience,
            claims: new List<Claim>
            {
                new(ClaimTypes.Name, user.Username)
            },
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey!)),
                SecurityAlgorithms.HmacSha256)
        ));

        // When
        var (isSuccessful, newToken) = await _tokenService.TryRefreshToken(recentlyExpiredToken);

        // Then
        isSuccessful.Should().BeFalse();
        newToken.Should().BeNullOrEmpty();
    }

    [Fact]
    public void TryRefreshToken_ShouldThrowSecurityTokenException_WhenTokenIsInvalid()
    {
        // Given
        var invalidToken = "invalid.token.here";

        // When
        var act = () =>
            _tokenService.TryRefreshToken(invalidToken);

        // Then
        act.Should().ThrowAsync<SecurityTokenException>().WithMessage("Invalid token");
    }
}