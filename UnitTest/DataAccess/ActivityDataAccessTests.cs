using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Moq;
using Npgsql;
using UnitTest.Fakes;
using UnitTest.Fakes.Models;
using UnitTest.Mocks;

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
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
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
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(model);

        // When
        var result = await _activityDataAccess.Update(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldRethrow()
    {
        // Given
        var model = new ActivityFaker().Generate();

        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Activity>()))
            .Returns((model.ActivityId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ThrowsAsync(new MockNpgsqlException(PgErrorCodes.ConcurrencyError));

        // When
        var act = async () => await _activityDataAccess.Update(model);

        // Then
        await act.Should().ThrowAsync<NpgsqlException>();
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
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
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

    [Fact]
    public async Task GetPaged_ShouldReturnPagedActivities_WhenExists()
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
        var result = await _activityDataAccess.GetPaged(0, 2, true);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task AssignCategory_ShouldExecuteQuery_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _activityDataAccess.AssignCategory(activityId, categoryId);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetAllByCategory_ShouldReturnActivities_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();
        var activities = new List<Activity>
        {
            new Activity { ActivityId = Guid.NewGuid(), CategoryId = categoryId, UserId = userId },
            new Activity { ActivityId = Guid.NewGuid(), CategoryId = categoryId, UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(activities);

        // When
        var result = await _activityDataAccess.GetAllByCategory(categoryId);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task ClearCategories_ShouldExecuteQuery_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _activityDataAccess.ClearCategories(activityId);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task AssignJob_ShouldExecuteQuery_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var jobId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _activityDataAccess.AssignJob(activityId, jobId);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task GetAllByJob_ShouldReturnActivities_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var jobId = Guid.NewGuid();
        var activities = new List<Activity>
        {
            new Activity { ActivityId = Guid.NewGuid(), JobId = jobId, UserId = userId },
            new Activity { ActivityId = Guid.NewGuid(), JobId = jobId, UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Activity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(activities);

        // When
        var result = await _activityDataAccess.GetAllByJob(jobId);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task ClearJobs_ShouldExecuteQuery_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        await _activityDataAccess.ClearJobs(activityId);

        // Then
        _dataBaseManagerMock.Verify(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }
}