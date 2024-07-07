using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.DataAccess;

public class RoleDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly RoleDataAccess _roleDataAccess;

    public RoleDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _roleDataAccess = new RoleDataAccess(_dataBaseManagerMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnIdentityResult_WhenInsertSucceeds()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), role))
            .ReturnsAsync(1);

        // When
        var result = await _roleDataAccess.CreateAsync(role, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnIdentityResult_WhenUpdateSucceeds()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), role))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _roleDataAccess.UpdateAsync(role, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnIdentityResult_WhenDeleteSucceeds()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), role))
            .Returns((It.IsAny<string>(), It.IsAny<DynamicParameters>()));
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _roleDataAccess.DeleteAsync(role, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task GetRoleIdAsync_ShouldReturnRoleId_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);

        // When
        var result = await _roleDataAccess.GetRoleIdAsync(role, CancellationToken.None);

        // Then
        result.Should().Be(role.RoleId.ToString());
    }

    [Fact]
    public async Task GetRoleNameAsync_ShouldReturnRoleName_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);

        // When
        var result = await _roleDataAccess.GetRoleNameAsync(role, CancellationToken.None);

        // Then
        result.Should().Be(role.Name);
    }

    [Fact]
    public async Task SetRoleNameAsync_ShouldUpdateRoleName_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();
        var newRoleName = "SuperAdmin";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _roleDataAccess.SetRoleNameAsync(role, newRoleName, CancellationToken.None);

        // Then
        role.Name.Should().Be(newRoleName);
    }

    [Fact]
    public async Task GetNormalizedRoleNameAsync_ShouldReturnNormalizedRoleName_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();
        role.NormalizedName = "ADMIN";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);

        // When
        var result = await _roleDataAccess.GetNormalizedRoleNameAsync(role, CancellationToken.None);

        // Then
        result.Should().Be(role.NormalizedName);
    }

    [Fact]
    public async Task SetNormalizedRoleNameAsync_ShouldUpdateNormalizedRoleName_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();
        role.NormalizedName = "ADMIN";
        var newNormalizedName = "SUPER ADMIN";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _roleDataAccess.SetNormalizedRoleNameAsync(role, newNormalizedName, CancellationToken.None);

        // Then
        role.NormalizedName.Should().Be(newNormalizedName);
    }

    [Fact]
    public async Task FindByIdAsync_ShouldReturnRole_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);

        // When
        var result = await _roleDataAccess.FindByIdAsync(role.RoleId.ToString(), CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(role);
    }

    [Fact]
    public async Task FindByNameOrThrowAsync_ShouldReturnRole_WhenRoleExists()
    {
        // Given
        var role = new RoleFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(role);

        // When
        var result = await _roleDataAccess.FindByNameOrThrowAsync(role.Name, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(role);
    }

    [Fact]
    public async Task FindByNameOrThrowAsync_ShouldThrowRoleNotFoundException_WhenRoleDoesNotExist()
    {
        // Given
        var roleName = "NonExistentRole";

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Role>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((Role)null!);

        // When
        Func<Task> act = async () => await _roleDataAccess.FindByNameOrThrowAsync(roleName, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<RoleNotFoundException>();
    }
}