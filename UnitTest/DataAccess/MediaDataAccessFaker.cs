using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.DataAccess;

public class MediaDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly IMediaDataAccess _mediaDataAccess;

    public MediaDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _mediaDataAccess = new MediaDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnMedia_WhenInsertSucceeds()
    {
        // Given
        var media = new MediaFaker().Generate();

        var returnedMedia = media;
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Media>(It.IsAny<string>(), media))
            .ReturnsAsync(returnedMedia);

        // When
        var result = await _mediaDataAccess.Create(media);

        // Then
        result.Should().BeEquivalentTo(returnedMedia);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedMedia_WhenUpdateSucceeds()
    {
        // Given
        var media = new MediaFaker().Generate();

        var returnedMedia = media;
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Media>()))
            .Returns((media.MediaId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Media>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedMedia);

        // When
        var result = await _mediaDataAccess.Update(media);

        // Then
        result.Should().BeEquivalentTo(returnedMedia);
    }

    [Fact]
    public async Task Get_ShouldReturnMedia_WhenExists()
    {
        // Given
        var mediaId = Guid.NewGuid();
        var returnedMedia = new Media
        {
            MediaId = mediaId,
            UserId = Guid.NewGuid()
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryFirstOrDefaultAsync<Media>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedMedia);

        // When
        var result = await _mediaDataAccess.Get(mediaId);

        // Then
        result.Should().BeEquivalentTo(returnedMedia);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnMedia_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var mediaList = new List<Media>
        {
            new() { MediaId = Guid.NewGuid(), UserId = userId },
            new() { MediaId = Guid.NewGuid(), UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Media>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(mediaList);

        // When
        var result = await _mediaDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(mediaList);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var mediaId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _mediaDataAccess.Delete(mediaId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var mediaId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(0);

        // When
        var result = await _mediaDataAccess.Delete(mediaId);

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetPaged_ShouldReturnPagedMedia_WhenExists()
    {
        // Given
        var startRow = 0;
        var count = 2;
        var mediaList = new List<Media>
        {
            new() { MediaId = Guid.NewGuid() },
            new() { MediaId = Guid.NewGuid() }
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Media>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(mediaList);

        // When
        var result = await _mediaDataAccess.GetPaged(startRow, count);

        // Then
        result.Should().BeEquivalentTo(mediaList);
    }
}