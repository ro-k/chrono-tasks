using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.DTOs;
using Lib.Services;
using Moq;

namespace UnitTest.DataAccess;

public class TreeViewDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly ITreeViewDataAccess _treeViewDataAccess;

    public TreeViewDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _treeViewDataAccess = new TreeViewDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnExpectedResults_WhenQuerySucceeds()
    {
        // Given
        var userId = Guid.NewGuid();
        var expectedCategories = new List<TreeViewCategoryDto>
        {
            new TreeViewCategoryDto { CategoryId = Guid.NewGuid(), Name = "Category 1" },
            new TreeViewCategoryDto { CategoryId = Guid.NewGuid(), Name = "Category 2" }
        };
        var expectedJobs = new List<TreeViewJobDto>
        {
            new TreeViewJobDto { JobId = Guid.NewGuid(), Name = "Job 1" },
            new TreeViewJobDto { JobId = Guid.NewGuid(), Name = "Job 2" }
        };
        var expectedActivities = new List<TreeViewActivityDto>
        {
            new TreeViewActivityDto { ActivityId = Guid.NewGuid(), Name = "Activity 1" },
            new TreeViewActivityDto { ActivityId = Guid.NewGuid(), Name = "Activity 2" }
        };

        var processGridReader = new Func<SqlMapper.GridReader, Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>(
            async reader =>
            {
                var categories = await reader.ReadAsync<TreeViewCategoryDto>();
                var jobs = await reader.ReadAsync<TreeViewJobDto>();
                var activities = await reader.ReadAsync<TreeViewActivityDto>();
                return (categories, jobs, activities);
            });

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryMultipleAsync(It.IsAny<Func<SqlMapper.GridReader,
                Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>>(), It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((expectedCategories, expectedJobs, expectedActivities));

        // When
        var result = await _treeViewDataAccess.GetAllByUserContext(processGridReader);

        // Then
        result.Item1.Should().BeEquivalentTo(expectedCategories);
        result.Item2.Should().BeEquivalentTo(expectedJobs);
        result.Item3.Should().BeEquivalentTo(expectedActivities);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldHandleEmptyResults_WhenNoDataExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var expectedCategories = new List<TreeViewCategoryDto>();
        var expectedJobs = new List<TreeViewJobDto>();
        var expectedActivities = new List<TreeViewActivityDto>();

        var processGridReader = new Func<SqlMapper.GridReader, Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>(
            async reader =>
            {
                var categories = await reader.ReadAsync<TreeViewCategoryDto>();
                var jobs = await reader.ReadAsync<TreeViewJobDto>();
                var activities = await reader.ReadAsync<TreeViewActivityDto>();
                return (categories, jobs, activities);
            });

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryMultipleAsync(It.IsAny<Func<SqlMapper.GridReader,
                Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>>(), It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((expectedCategories, expectedJobs, expectedActivities));

        // When
        var result = await _treeViewDataAccess.GetAllByUserContext(processGridReader);

        // Then
        result.Item1.Should().BeEmpty();
        result.Item2.Should().BeEmpty();
        result.Item3.Should().BeEmpty();
    }
}