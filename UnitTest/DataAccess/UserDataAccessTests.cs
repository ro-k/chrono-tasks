using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using UnitTest.Fakes.Models;
using UnitTest.Mocks;
// ReSharper disable StringLiteralTypo

namespace UnitTest.DataAccess;

public class UserDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IRoleDataAccess> _roleDataAccessMock;
    private readonly IUserDataAccess _userDataAccess;

    public UserDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _roleDataAccessMock = new Mock<IRoleDataAccess>();
        _userDataAccess = new UserDataAccess(_dataBaseManagerMock.Object, _roleDataAccessMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnIdentityResult_WhenInsertSucceeds()
    {
        // Given
        var user = new UserFaker().Generate();
        user.UserId = Guid.Empty;

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), user))
            .ReturnsAsync(1);

        // When
        var result = await _userDataAccess.CreateAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnIdentityResult_WhenUpdateSucceeds()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), user))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _userDataAccess.UpdateAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnFailedIdentityResult_WhenNoUserId()
    {
        // Given
        var user = new UserFaker().Generate();
        user.UserId = Guid.Empty;
        var expectedResult = IdentityResult.Failed([new IdentityError { Description = "Invalid UserId" }]);

        // When
        var result = await _userDataAccess.UpdateAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnFailedIdentityResult_WhenUpdateFails()
    {
        // Given
        var user = new UserFaker().Generate();
        var expectedResult = IdentityResult.Failed(new IdentityError
            { Code = PgErrorCodes.ConcurrencyError, Description = "External component has thrown an exception." });

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), user))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ThrowsAsync(new MockNpgsqlException(PgErrorCodes.ConcurrencyError));

        // When
        var result = await _userDataAccess.UpdateAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnIdentityResult_WhenDeleteSucceeds()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), user))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _userDataAccess.DeleteAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFailedIdentityResult_WhenConcurrencyExceptionIsThrown()
    {
        // Given
        var user = new UserFaker().Generate();
        var expectedResult = IdentityResult.Failed(new IdentityError
            { Code = PgErrorCodes.ConcurrencyError, Description = "External component has thrown an exception." });

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), user))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ThrowsAsync(new MockNpgsqlException(PgErrorCodes.ConcurrencyError));

        // When
        var result = await _userDataAccess.DeleteAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task FindByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock.Setup(dbm =>
                dbm.QuerySingleOrDefaultAsync<User?>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByIdAsync(user.UserId.ToString(), CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("not a guid")]
    public async Task FindByIdAsync_ShouldReturnNull_WhenInvalidId(string? userId)
    {
        // Given

        _dataBaseManagerMock.Setup(dbm =>
                dbm.QuerySingleOrDefaultAsync<User?>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((User)null!);

        // When
        var result = await _userDataAccess.FindByIdAsync(userId!, CancellationToken.None);

        // Then
        result.Should().BeNull();
    }

    [Fact]
    public async Task FindByNameAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByNameAsync(user.Username, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByNameAsync_ShouldReturnNull_WhenNullUserName()
    {
        // Given
        var user = new UserFaker().Generate();
        user.Username = null!;

        // When
        var result = await _userDataAccess.FindByNameAsync(user.Username, CancellationToken.None);

        // Then
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddToRoleAsync_ShouldAddUserRole_WhenRoleExists()
    {
        // Given
        var user = new UserFaker().Generate();
        var role = new RoleFaker().Generate();

        _roleDataAccessMock.Setup(rda => rda.FindByNameOrThrowAsync(role.Name, CancellationToken.None))
            .ReturnsAsync(role);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.AddToRoleAsync(user, role.Name, CancellationToken.None);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetUserIdAsync_ShouldReturnUserId_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetUserIdAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.UserId.ToString());
    }

    [Fact]
    public async Task GetUserNameAsync_ShouldReturnUserName_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetUserNameAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.Username);
    }

    [Fact]
    public async Task SetUserNameAsync_ShouldUpdateUserName_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var newUserName = "updateduser";

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetUserNameAsync(user, newUserName, CancellationToken.None);

        // Then
        user.Username.Should().Be(newUserName);
    }

    [Fact]
    public async Task SetUserNameAsync_ShouldThrowArgumentNullException_WhenNullUserName()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid()
        };

        // When
        var act = () => _userDataAccess.SetUserNameAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GetNormalizedUserNameAsync_ShouldReturnNormalizedUserName_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedUserName = "TESTUSER"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetNormalizedUserNameAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.NormalizedUserName);
    }

    [Fact]
    public async Task SetNormalizedUserNameAsync_ShouldUpdateNormalizedUserName_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedUserName = "TESTUSER"
        };
        var newNormalizedUserName = "UPDATEDUSER";

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetNormalizedUserNameAsync(user, newNormalizedUserName, CancellationToken.None);

        // Then
        user.NormalizedUserName.Should().Be(newNormalizedUserName);
    }

    [Fact]
    public async Task SetNormalizedUserNameAsync_ShouldThrowArgumentNullException_WhenNullNormalizedUserName()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedUserName = "TESTUSER"
        };

        // When
        var act = () => _userDataAccess.SetNormalizedUserNameAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task SetPasswordHashAsync_ShouldUpdatePasswordHash_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PasswordHash = "oldhash"
        };
        var newPasswordHash = "newhash";

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetPasswordHashAsync(user, newPasswordHash, CancellationToken.None);

        // Then
        user.PasswordHash.Should().Be(newPasswordHash);
    }

    [Fact]
    public async Task SetPasswordHashAsync_ShouldThrowArgumentNullException_WhenNullNewPasswordHash()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PasswordHash = "oldhash"
        };

        // When
        var act = () => _userDataAccess.SetPasswordHashAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GetPasswordHashAsync_ShouldReturnPasswordHash_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PasswordHash = "testhash"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetPasswordHashAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.PasswordHash);
    }

    [Fact]
    public async Task HasPasswordAsync_ShouldReturnTrue_WhenUserHasPassword()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PasswordHash = "testhash"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.HasPasswordAsync(user, CancellationToken.None);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task RemoveFromRoleAsync_ShouldRemoveUserRole_WhenRoleExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var roleName = "Admin";
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            Name = roleName
        };

        _roleDataAccessMock.Setup(rda => rda.FindByNameOrThrowAsync(roleName, CancellationToken.None))
            .ReturnsAsync(role);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.RemoveFromRoleAsync(user, roleName, CancellationToken.None);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetRolesAsync_ShouldReturnRoles_WhenUserHasRoles()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var roles = new List<string> { "Admin", "User" };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<string>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(roles);

        // When
        var result = await _userDataAccess.GetRolesAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(roles);
    }

    [Fact]
    public async Task IsInRoleAsync_ShouldReturnTrue_WhenUserIsInRole()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var roleName = "Admin";
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            Name = roleName
        };

        _roleDataAccessMock.Setup(rda => rda.FindByNameOrThrowAsync(roleName, CancellationToken.None))
            .ReturnsAsync(role);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteScalarAsync<bool>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(true);

        // When
        var result = await _userDataAccess.IsInRoleAsync(user, roleName, CancellationToken.None);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task GetUsersInRoleAsync_ShouldReturnUsers_WhenRoleExists()
    {
        // Given
        var roleName = "Admin";
        var users = new List<User>
        {
            new() { UserId = Guid.NewGuid(), Username = "user1" },
            new() { UserId = Guid.NewGuid(), Username = "user2" }
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(users);

        // When
        var result = await _userDataAccess.GetUsersInRoleAsync(roleName, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(users);
    }

    [Fact]
    public async Task SetEmailAsync_ShouldUpdateEmail_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Email = "oldemail@example.com"
        };
        var newEmail = "newemail@example.com";

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetEmailAsync(user, newEmail, CancellationToken.None);

        // Then
        user.Email.Should().Be(newEmail);
    }

    [Fact]
    public async Task SetEmailAsync_ShouldThrowArgumentException_WhenNullNewEmail()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Email = "oldemail@example.com"
        };

        // When
        var act = () => _userDataAccess.SetEmailAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task GetEmailAsync_ShouldReturnEmail_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Email = "testemail@example.com"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetEmailAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.Email);
    }

    [Fact]
    public async Task GetEmailConfirmedAsync_ShouldReturnTrue_WhenEmailIsConfirmed()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            EmailConfirmed = true
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetEmailConfirmedAsync(user, CancellationToken.None);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task SetEmailConfirmedAsync_ShouldUpdateEmailConfirmed_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            EmailConfirmed = false
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetEmailConfirmedAsync(user, true, CancellationToken.None);

        // Then
        user.EmailConfirmed.Should().BeTrue();
    }

    [Fact]
    public async Task FindByEmailAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var email = "testemail@example.com";
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Email = email
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByEmailAsync(email, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByEmailAsync_ShouldReturnNull_WhenNoEmail()
    {
        // Given

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((User)null!);

        // When
        var result = await _userDataAccess.FindByEmailAsync(null!, CancellationToken.None);

        // Then
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetNormalizedEmailAsync_ShouldReturnNormalizedEmail_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedEmail = "TESTEMAIL@EXAMPLE.COM"
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetNormalizedEmailAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.NormalizedEmail);
    }

    [Fact]
    public async Task SetNormalizedEmailAsync_ShouldUpdateNormalizedEmail_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedEmail = "TESTEMAIL@EXAMPLE.COM"
        };
        var newNormalizedEmail = "NEWEMAIL@EXAMPLE.COM";

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetNormalizedEmailAsync(user, newNormalizedEmail, CancellationToken.None);

        // Then
        user.NormalizedEmail.Should().Be(newNormalizedEmail);
    }

    [Fact]
    public async Task SetNormalizedEmailAsync_ShouldThrowArgumentNullException_WhenNullNewNormalizedEmail()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            NormalizedEmail = "TESTEMAIL@EXAMPLE.COM"
        };

        // When
        var act = () => _userDataAccess.SetNormalizedEmailAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GetLockoutEndDateAsync_ShouldReturnLockoutEndDate_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetLockoutEndDateAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.LockoutEnd);
    }

    [Fact]
    public async Task SetLockoutEndDateAsync_ShouldUpdateLockoutEndDate_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();
        var newLockoutEnd = DateTimeOffset.UtcNow.AddMinutes(5);

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetLockoutEndDateAsync(user, newLockoutEnd, CancellationToken.None);

        // Then
        user.LockoutEnd.Should().Be(newLockoutEnd.UtcDateTime);
    }

    [Fact]
    public async Task IncrementAccessFailedCountAsync_ShouldIncrementFailedCount_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            AccessFailedCount = 0
        };

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _userDataAccess.IncrementAccessFailedCountAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(1);
    }

    [Fact]
    public async Task ResetAccessFailedCountAsync_ShouldResetFailedCount_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            AccessFailedCount = 1
        };

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.ResetAccessFailedCountAsync(user, CancellationToken.None);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetAccessFailedCountAsync_ShouldReturnFailedCount_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            AccessFailedCount = 3
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetAccessFailedCountAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.AccessFailedCount);
    }

    [Fact]
    public async Task GetLockoutEnabledAsync_ShouldReturnLockoutEnabled_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            LockoutEnabled = true
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetLockoutEnabledAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.LockoutEnabled);
    }

    [Fact]
    public async Task SetLockoutEnabledAsync_ShouldUpdateLockoutEnabled_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            LockoutEnabled = false
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetLockoutEnabledAsync(user, true, CancellationToken.None);

        // Then
        user.LockoutEnabled.Should().BeTrue();
    }

    [Fact]
    public async Task SetPhoneNumberAsync_ShouldUpdatePhoneNumber_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PhoneNumber = "1234567890"
        };
        var newPhoneNumber = "0987654321";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetPhoneNumberAsync(user, newPhoneNumber, CancellationToken.None);

        // Then
        user.PhoneNumber.Should().Be(newPhoneNumber);
    }

    [Fact]
    public async Task SetPhoneNumberAsync_ShouldThrowArgumentNullException_WhenNullNewPhoneNumber()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PhoneNumber = "1234567890"
        };

        // When
        var act = () => _userDataAccess.SetPhoneNumberAsync(user, null, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GetPhoneNumberAsync_ShouldReturnPhoneNumber_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PhoneNumber = "1234567890"
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetPhoneNumberAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.PhoneNumber);
    }

    [Fact]
    public async Task GetPhoneNumberConfirmedAsync_ShouldReturnTrue_WhenPhoneNumberIsConfirmed()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PhoneNumberConfirmed = true
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetPhoneNumberConfirmedAsync(user, CancellationToken.None);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task SetPhoneNumberConfirmedAsync_ShouldUpdatePhoneNumberConfirmed_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            PhoneNumberConfirmed = false
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetPhoneNumberConfirmedAsync(user, true, CancellationToken.None);

        // Then
        user.PhoneNumberConfirmed.Should().BeTrue();
    }

    [Fact]
    public async Task SetSecurityStampAsync_ShouldUpdateSecurityStamp_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            SecurityStamp = "oldstamp"
        };
        var newSecurityStamp = "newstamp";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.SetSecurityStampAsync(user, newSecurityStamp, CancellationToken.None);

        // Then
        user.SecurityStamp.Should().Be(newSecurityStamp);
    }

    [Fact]
    public async Task GetSecurityStampAsync_ShouldReturnSecurityStamp_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            SecurityStamp = "teststamp"
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.GetSecurityStampAsync(user, CancellationToken.None);

        // Then
        result.Should().Be(user.SecurityStamp);
    }

    [Fact]
    public async Task AddLoginAsync_ShouldAddUserLogin_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var loginInfo = new UserLoginInfo("provider", "key", "displayName");

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.AddLoginAsync(user, loginInfo, CancellationToken.None);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task RemoveLoginAsync_ShouldRemoveUserLogin_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var loginProvider = "provider";
        var providerKey = "key";

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _userDataAccess.RemoveLoginAsync(user, loginProvider, providerKey, CancellationToken.None);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetLoginsAsync_ShouldReturnUserLogins_WhenUserExists()
    {
        // Given
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };
        var userLogins = new List<UserLogin>
        {
            new()
            {
                UserId = user.UserId, LoginProvider = "provider1", ProviderKey = "key1",
                ProviderDisplayName = "displayName1"
            },
            new()
            {
                UserId = user.UserId, LoginProvider = "provider2", ProviderKey = "key2",
                ProviderDisplayName = "displayName2"
            }
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<UserLogin>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(userLogins);

        // When
        var result = await _userDataAccess.GetLoginsAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(userLogins
            .Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.ProviderDisplayName)).ToList());
    }

    [Fact]
    public async Task FindByLoginAsync_ShouldReturnUser_WhenLoginExists()
    {
        // Given
        var loginProvider = "provider";
        var providerKey = "key";
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser"
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByLoginAsync(loginProvider, providerKey, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByUserNameOrThrowAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByUserNameOrThrowAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByUserNameOrThrowAsync_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((User)null!);

        // When
        Func<Task> act = async () => await _userDataAccess.FindByUserNameOrThrowAsync(user, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task FindByUserNameOrThrowAsync_ShouldThrowArgumentNullException_WhenNoUserName()
    {
        // Given
        var user = new UserFaker().Generate();
        user.Username = null!;

        // When
        Func<Task> act = async () => await _userDataAccess.FindByUserNameOrThrowAsync(user, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task FindByEmailOrThrowAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByEmailOrThrowAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByEmailOrThrowAsync_ShouldReturnSameUser_WhenNoUserId()
    {
        // Given
        var user = new UserFaker().Generate();
        user.UserId = Guid.Empty;

        // When
        var result = await _userDataAccess.FindByEmailOrThrowAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByEmailOrThrowAsync_ShouldThrowArgumentNullException_WhenNoEmail()
    {
        // Given
        var user = new UserFaker().Generate();
        user.Email = null!;

        // When
        Func<Task> act = async () => await _userDataAccess.FindByEmailOrThrowAsync(user, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task FindByEmailOrThrowAsync_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((User)null!);

        // When
        Func<Task> act = async () => await _userDataAccess.FindByEmailOrThrowAsync(user, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task FindByIdOrThrowAsync_ShouldReturnUser_WhenUserExists()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(user);

        // When
        var result = await _userDataAccess.FindByIdOrThrowAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByIdOrThrowAsync_ShouldReturnUser_WhenUserIdNotSet()
    {
        // Given
        var user = new UserFaker().Generate();
        user.UserId = Guid.Empty;

        // When
        var result = await _userDataAccess.FindByIdOrThrowAsync(user, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task FindByIdOrThrowAsync_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
    {
        // Given
        var user = new UserFaker().Generate();

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))!
            .ReturnsAsync((User?)null);

        // When
        Func<Task> act = async () => await _userDataAccess.FindByIdOrThrowAsync(user, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<UserNotFoundException>();
    }
}