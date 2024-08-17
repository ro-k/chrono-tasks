using FluentAssertions;
using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;
using Lib.Services;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.Services;

public class ActivityServiceTests
{
    private readonly Mock<IActivityDataAccess> _activityDataAccessMock;
    private readonly IActivityService _activityService;
    private readonly ActivityFaker _activityFaker = new();

    public ActivityServiceTests()
    {
        _activityDataAccessMock = new Mock<IActivityDataAccess>();
        _activityService = new ActivityService(_activityDataAccessMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnActivity_WhenInsertSucceeds()
    {
        // Given
        var model = _activityFaker.Generate();

        _activityDataAccessMock.Setup(ada => ada.Create(It.IsAny<Activity>()))
            .ReturnsAsync(model);

        // When
        var result = await _activityService.Create(model.CategoryId, model.JobId, model.Name, model.Description, model.StartTime, model.EndTime);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedActivity_WhenUpdateSucceeds()
    {
        // Given
        var model = _activityFaker.Generate();
        var current = _activityFaker.Generate();
        current.ActivityId = model.ActivityId;
        current.ConcurrencyStamp = model.ConcurrencyStamp;

        _activityDataAccessMock.Setup(ada => ada.Get(model.ActivityId)).ReturnsAsync(current);
        _activityDataAccessMock.Setup(ada => ada.Update(It.IsAny<Activity>())).ReturnsAsync(model);

        // When
        var result = await _activityService.Update(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldThrowConcurrencyStampMismatchException_WhenStampsDoNotMatch()
    {
        // Given
        var model = _activityFaker.Generate();
        var current = _activityFaker.Generate();
        current.ActivityId = model.ActivityId;
        current.ConcurrencyStamp = Guid.NewGuid();

        _activityDataAccessMock.Setup(ada => ada.Get(model.ActivityId)).ReturnsAsync(current);

        // When
        Func<Task> act = async () => await _activityService.Update(model);

        // Then
        await act.Should().ThrowAsync<ConcurrencyStampMismatchException>();
    }

    [Fact]
    public async Task Get_ShouldReturnActivity_WhenExists()
    {
        // Given
        var model = _activityFaker.Generate();

        _activityDataAccessMock.Setup(ada => ada.Get(model.ActivityId)).ReturnsAsync(model);

        // When
        var result = await _activityService.Get(model.ActivityId);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task GetPaged_ShouldReturnPagedActivities_WhenExists()
    {
        // Given
        var activities = _activityFaker.Generate(2);

        _activityDataAccessMock.Setup(ada => ada.GetPaged(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(activities);

        // When
        var result = await _activityService.GetPaged(0, 2);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var activityId = Guid.NewGuid();

        _activityDataAccessMock.Setup(ada => ada.Delete(activityId)).ReturnsAsync(true);

        // When
        var result = await _activityService.Delete(activityId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var activityId = Guid.NewGuid();

        _activityDataAccessMock.Setup(ada => ada.Delete(activityId)).ReturnsAsync(false);

        // When
        var result = await _activityService.Delete(activityId);

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public async Task AssignCategory_ShouldCallDataAccessAssignCategory_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();

        // When
        await _activityService.AssignCategory(activityId, categoryId);

        // Then
        _activityDataAccessMock.Verify(ada => ada.AssignCategory(activityId, categoryId, true), Times.Once);
    }

    [Fact]
    public async Task GetAllByCategory_ShouldReturnActivities_WhenExists()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var activities = _activityFaker.Generate(2);

        _activityDataAccessMock.Setup(ada => ada.GetAllByCategory(categoryId)).ReturnsAsync(activities);

        // When
        var result = await _activityService.GetAllByCategory(categoryId);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task ClearCategories_ShouldCallDataAccessClearCategories_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();

        // When
        await _activityService.ClearCategories(activityId);

        // Then
        _activityDataAccessMock.Verify(ada => ada.ClearCategories(activityId), Times.Once);
    }

    [Fact]
    public async Task AssignJob_ShouldCallDataAccessAssignJob_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();
        var jobId = Guid.NewGuid();

        // When
        await _activityService.AssignJob(activityId, jobId);

        // Then
        _activityDataAccessMock.Verify(ada => ada.AssignJob(activityId, jobId, true), Times.Once);
    }

    [Fact]
    public async Task GetAllByJob_ShouldReturnActivities_WhenExists()
    {
        // Given
        var jobId = Guid.NewGuid();
        var activities = _activityFaker.Generate(2);

        _activityDataAccessMock.Setup(ada => ada.GetAllByJob(jobId)).ReturnsAsync(activities);

        // When
        var result = await _activityService.GetAllByJob(jobId);

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task ClearJobs_ShouldCallDataAccessClearJobs_WhenCalled()
    {
        // Given
        var activityId = Guid.NewGuid();

        // When
        await _activityService.ClearJobs(activityId);

        // Then
        _activityDataAccessMock.Verify(ada => ada.ClearJobs(activityId), Times.Once);
    }
    
    [Fact]
    public async Task GetAllByUserContext_ShouldReturnActivities_WhenExists()
    {
        // Given
        var activities = _activityFaker.Generate(2);

        _activityDataAccessMock.Setup(ada => ada.GetAllByUserContext(true))
            .ReturnsAsync(activities);

        // When
        var result = await _activityService.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(activities);
    }

    [Fact]
    public async Task GetByParent_ShouldReturnActivitiesByCategory_WhenCategoryIdIsProvided()
    {
        // Given
            var categoryId = Guid.NewGuid();
            var activities = _activityFaker.Generate(2);

            _activityDataAccessMock.Setup(ada => ada.GetAllByCategory(categoryId))
                .ReturnsAsync(activities);

            // When
            var result = await _activityService.GetByParent(categoryId, null);

            // Then
            result.Should().BeEquivalentTo(activities);
        }

        [Fact]
        public async Task GetByParent_ShouldReturnActivitiesByJob_WhenJobIdIsProvided()
        {
            // Given
            var jobId = Guid.NewGuid();
            var activities = _activityFaker.Generate(2);

            _activityDataAccessMock.Setup(ada => ada.GetAllByJob(jobId))
                .ReturnsAsync(activities);

            // When
            var result = await _activityService.GetByParent(null, jobId);

            // Then
            result.Should().BeEquivalentTo(activities);
        }

        [Fact]
        public async Task GetByParent_ShouldReturnEmptyList_WhenNoIdsAreProvided()
        {
            // When
            var result = await _activityService.GetByParent(null, null);

            // Then
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateParents_ShouldClearCategoriesAndJobs_WhenNoIdsAreProvided()
        {
            // Given
            var activityId = Guid.NewGuid();

            // When
            await _activityService.UpdateParents(activityId, null, null);

            // Then
            _activityDataAccessMock.Verify(ada => ada.ClearCategories(activityId), Times.Once);
            _activityDataAccessMock.Verify(ada => ada.ClearJobs(activityId), Times.Once);
        }

        [Fact]
        public async Task UpdateParents_ShouldAssignCategory_WhenCategoryIdIsProvided()
        {
            // Given
            var activityId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();

            // When
            await _activityService.UpdateParents(activityId, categoryId, null);

            // Then
            _activityDataAccessMock.Verify(ada => ada.AssignCategory(activityId, categoryId, true), Times.Once);
        }

        [Fact]
        public async Task UpdateParents_ShouldAssignJob_WhenJobIdIsProvided()
        {
            // Given
            var activityId = Guid.NewGuid();
            var jobId = Guid.NewGuid();

            // When
            await _activityService.UpdateParents(activityId, null, jobId);

            // Then
            _activityDataAccessMock.Verify(ada => ada.AssignJob(activityId, jobId, true), Times.Once);
        }

        [Fact]
        public async Task UpdateParents_ShouldAssignCategoryAndJob_WhenBothIdsAreProvided()
        {
            // Given
            var activityId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var jobId = Guid.NewGuid();

            // When
            await _activityService.UpdateParents(activityId, categoryId, jobId);

            // Then
            _activityDataAccessMock.Verify(ada => ada.AssignCategory(activityId, categoryId, true), Times.Once);
            _activityDataAccessMock.Verify(ada => ada.AssignJob(activityId, jobId, true), Times.Once);
        }
}