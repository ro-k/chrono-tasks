using FluentAssertions;
using Lib.DataAccess;
using Lib.Services;
using Moq;

namespace UnitTest.DataAccess;

public class ParentDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly IParentDataAccess _parentDataAccess;

    public ParentDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _parentDataAccess = new ParentDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnGuidList_WhenDataExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var expectedGuids = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid()
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Guid>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedGuids);

        // When
        var result = await _parentDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(expectedGuids);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnEmptyList_WhenNoDataExists()
    {
        // Given
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Guid>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(new List<Guid>());

        // When
        var result = await _parentDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEmpty();
    }
}