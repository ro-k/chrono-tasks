using FluentAssertions;
using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;
using Lib.Services;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.Services;

public class JobServiceTests
{
    private readonly Mock<IJobDataAccess> _jobDataAccessMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly IJobService _jobService;

    public JobServiceTests()
    {
        _jobDataAccessMock = new Mock<IJobDataAccess>();
        _userContextMock = new Mock<IUserContext>();
        _jobService = new JobService(_jobDataAccessMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnJob_WhenInsertSucceeds()
    {
        // Given
        var model = new JobFaker().Generate();
        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _jobDataAccessMock.Setup(jda => jda.Create(It.IsAny<Job>())).ReturnsAsync(model);

        // When
        var result = await _jobService.Create(model.CategoryId, model.Name, model.Description, model.Data);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Create_WithJobModel_ShouldReturnJob_WhenInsertSucceeds()
    {
        // Given
        var model = new JobFaker().Generate();
        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _jobDataAccessMock.Setup(jda => jda.Create(It.IsAny<Job>())).ReturnsAsync(model);

        // When
        var result = await _jobService.Create(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Get_ShouldReturnJob_WhenExists()
    {
        // Given
        var model = new JobFaker().Generate();

        _jobDataAccessMock.Setup(jda => jda.Get(model.JobId)).ReturnsAsync(model);

        // When
        var result = await _jobService.Get(model.JobId);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task GetPaged_ShouldReturnPagedJobs_WhenExists()
    {
        // Given
        var jobs = new List<Job>
        {
            new JobFaker().Generate(),
            new JobFaker().Generate()
        };

        _jobDataAccessMock.Setup(jda => jda.GetPaged(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(jobs);

        // When
        var result = await _jobService.GetPaged(0, 2);

        // Then
        result.Should().BeEquivalentTo(jobs);
    }

    [Fact]
    public async Task GetAllByCategoryId_ShouldReturnJobs_WhenExists()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var jobs = new List<Job>
        {
            new JobFaker().Generate(),
            new JobFaker().Generate()
        };

        _jobDataAccessMock.Setup(jda => jda.GetAllByCategoryId(categoryId, true)).ReturnsAsync(jobs);

        // When
        var result = await _jobService.GetAllByCategoryId(categoryId);

        // Then
        result.Should().BeEquivalentTo(jobs);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedJob_WhenUpdateSucceeds()
    {
        // Given
        var model = new JobFaker().Generate();
        var current = new JobFaker().Generate();
        current.JobId = model.JobId;
        current.ConcurrencyStamp = model.ConcurrencyStamp;

        _jobDataAccessMock.Setup(jda => jda.Get(model.JobId)).ReturnsAsync(current);
        _jobDataAccessMock.Setup(jda => jda.Update(It.IsAny<Job>())).ReturnsAsync(model);

        // When
        var result = await _jobService.Update(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldThrowConcurrencyStampMismatchException_WhenStampsDoNotMatch()
    {
        // Given
        var model = new JobFaker().Generate();
        var current = new JobFaker().Generate();
        current.JobId = model.JobId;
        current.ConcurrencyStamp = Guid.NewGuid();

        _jobDataAccessMock.Setup(jda => jda.Get(model.JobId)).ReturnsAsync(current);

        // When
        Func<Task> act = async () => await _jobService.Update(model);

        // Then
        await act.Should().ThrowAsync<ConcurrencyStampMismatchException>();
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnJobs_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var jobs = new List<Job>
        {
            new JobFaker().Generate(),
            new JobFaker().Generate()
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _jobDataAccessMock.Setup(jda => jda.GetAllByUserContext(true)).ReturnsAsync(jobs);

        // When
        var result = await _jobService.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(jobs);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var jobId = Guid.NewGuid();

        _jobDataAccessMock.Setup(jda => jda.Delete(jobId)).ReturnsAsync(true);

        // When
        var result = await _jobService.Delete(jobId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var jobId = Guid.NewGuid();

        _jobDataAccessMock.Setup(jda => jda.Delete(jobId)).ReturnsAsync(false);

        // When
        var result = await _jobService.Delete(jobId);

        // Then
        result.Should().BeFalse();
    }
}