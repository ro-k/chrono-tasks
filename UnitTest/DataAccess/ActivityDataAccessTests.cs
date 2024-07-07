using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.DataAccess;

public class ActivityDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly IActivityDataAccess _activityDataAccess;

    public ActivityDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _activityDataAccess = new ActivityDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnActivity_WhenInsertSucceeds()
    {
        // Given
        var model = new ActivityFaker().Generate();

        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(model);

        // When
        var result = await _activityDataAccess.Create(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedActivity_WhenUpdateSucceeds()
    {
        // Given
        var model = new ActivityFaker().Generate();

        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Activity>()))
            .Returns((model.ActivityId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(model);

        // When
        var result = await _activityDataAccess.Update(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Get_ShouldReturnActivity_WhenExists()
    {
        // Given
        var activityId = Guid.NewGuid();
        var returnedActivity = new Activity
        {
            ActivityId = activityId,
            UserId = Guid.NewGuid()
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(returnedActivity.UserId);
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedActivity);

        // When
        var result = await _activityDataAccess.Get(activityId);

        // Then
        result.Should().BeEquivalentTo(returnedActivity);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnActivities_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var activities = new List<Activity>
        {
            new Activity { ActivityId = Guid.NewGuid(), UserId = userId },
            new Activity { ActivityId = Guid.NewGuid(), UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(activities);

        // When
        var result = await _activityDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var activityId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _activityDataAccess.Delete(activityId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var activityId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(0);

        // When
        var result = await _activityDataAccess.Delete(activityId);

        // Then
        result.Should().BeFalse();
    }
}