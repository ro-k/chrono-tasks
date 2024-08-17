using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Moq;
using Npgsql;
using UnitTest.Fakes.Models;
using UnitTest.Mocks;

namespace UnitTest.DataAccess;

public class JobDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly IJobDataAccess _jobDataAccess;

    public JobDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _jobDataAccess = new JobDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnJob_WhenInsertSucceeds()
    {
        // Given
        var model = new JobFaker().Generate();

        var returnedJob = model;
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Job>(It.IsAny<string>(), model))
            .ReturnsAsync(returnedJob);

        // When
        var result = await _jobDataAccess.Create(model);

        // Then
        result.Should().BeEquivalentTo(returnedJob);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedJob_WhenUpdateSucceeds()
    {
        // Given
        var model = new JobFaker().Generate();

        var returnedJob = model;
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Job>()))
            .Returns((model.JobId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedJob);

        // When
        var result = await _jobDataAccess.Update(model);

        // Then
        result.Should().BeEquivalentTo(returnedJob);
    }

    [Fact]
    public async Task Update_ShouldRethrowException_WhenUpdateFails()
    {
        // Given
        var model = new JobFaker().Generate();

        var returnedJob = model;
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Job>()))
            .Returns((model.JobId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ThrowsAsync(new MockNpgsqlException(PgErrorCodes.ConcurrencyError));

        // When
        var act = () => _jobDataAccess.Update(model);

        // Then
        await act.Should().ThrowAsync<NpgsqlException>();
    }

    [Fact]
    public async Task Get_ShouldReturnJob_WhenExists()
    {
        // Given
        var jobId = Guid.NewGuid();
        var returnedJob = new Job
        {
            JobId = jobId,
            UserId = Guid.NewGuid()
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedJob);

        // When
        var result = await _jobDataAccess.Get(jobId);

        // Then
        result.Should().BeEquivalentTo(returnedJob);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnJobs_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var jobs = new List<Job>
        {
            new() { JobId = Guid.NewGuid(), UserId = userId },
            new() { JobId = Guid.NewGuid(), UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(jobs);

        // When
        var result = await _jobDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(jobs);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var jobId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _jobDataAccess.Delete(jobId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var jobId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(0);

        // When
        var result = await _jobDataAccess.Delete(jobId);

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetAllByCategoryId_ShouldReturnJobs_WhenExists()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var jobs = new List<Job>
        {
            new() { JobId = Guid.NewGuid(), CategoryId = categoryId, UserId = userId },
            new() { JobId = Guid.NewGuid(), CategoryId = categoryId, UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(jobs);

        // When
        var result = await _jobDataAccess.GetAllByCategoryId(categoryId);

        // Then
        result.Should().BeEquivalentTo(jobs);
    }

    [Fact]
    public async Task GetPaged_ShouldReturnJobs_WhenCalledWithDefaults()
    {
        // Given
        var jobs = new List<Job>
        {
            new() { JobId = Guid.NewGuid(), Name = "Job 1" },
            new() { JobId = Guid.NewGuid(), Name = "Job 2" }
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Job>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(jobs);

        // When
        var result = await _jobDataAccess.GetPaged();

        // Then
        result.Should().BeEquivalentTo(jobs);
    }
}