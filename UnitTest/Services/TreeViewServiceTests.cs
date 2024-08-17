using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.DTOs;
using Lib.Services;
using Moq;

namespace UnitTest.Services
{
    public class TreeViewServiceTests
    {
        private readonly Mock<ITreeViewDataAccess> _treeViewDataAccessMock;
        private readonly ITreeViewService _treeViewService;

        public TreeViewServiceTests()
        {
            _treeViewDataAccessMock = new Mock<ITreeViewDataAccess>();
            _treeViewService = new TreeViewService(_treeViewDataAccessMock.Object);
        }

        [Fact]
        public async Task GetAllByUserContext_ShouldReturnTreeViewDto_WhenDataExists()
        {
            // Given
            var categories = new List<TreeViewCategoryDto>
            {
                new() { CategoryId = Guid.NewGuid(), Name = "Category 1" },
                new() { CategoryId = Guid.NewGuid(), Name = "Category 2" }
            };

            var jobs = new List<TreeViewJobDto>
            {
                new() { JobId = Guid.NewGuid(), CategoryId = categories[0].CategoryId, Name = "Job 1" },
                new() { JobId = Guid.NewGuid(), CategoryId = categories[1].CategoryId, Name = "Job 2" }
            };

            var activities = new List<TreeViewActivityDto>
            {
                new() { ActivityId = Guid.NewGuid(), CategoryId = categories[0].CategoryId, JobId = jobs[0].JobId, Name = "Activity 1" },
                new() { ActivityId = Guid.NewGuid(), CategoryId = categories[1].CategoryId, JobId = jobs[1].JobId, Name = "Activity 2" }
            };

            _treeViewDataAccessMock.Setup(tda => tda.GetAllByUserContext(It.IsAny<Func<SqlMapper.GridReader, Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>>(), true))
                .ReturnsAsync((categories, jobs, activities));

            // When
            var result = await _treeViewService.GetAllByUserContext();

            // Then
            result.Categories.Should().HaveCount(2);
            result.Categories[0].TreeViewJobs.Should().HaveCount(1);
            result.Categories[1].TreeViewJobs.Should().HaveCount(1);
            result.Categories[0].TreeViewJobs[0].TreeViewActivities.Should().ContainSingle(a => a.Name == "Activity 1");
            result.Categories[1].TreeViewJobs[0].TreeViewActivities.Should().ContainSingle(a => a.Name == "Activity 2");
        }

        [Fact]
        public async Task GetAllByUserContext_ShouldReturnEmptyTreeViewDto_WhenNoDataExists()
        {
            // Given
            var categories = Enumerable.Empty<TreeViewCategoryDto>();
            var jobs = Enumerable.Empty<TreeViewJobDto>();
            var activities = Enumerable.Empty<TreeViewActivityDto>();

            _treeViewDataAccessMock.Setup(tda => tda.GetAllByUserContext(It.IsAny<Func<SqlMapper.GridReader, Task<(IEnumerable<TreeViewCategoryDto>, IEnumerable<TreeViewJobDto>, IEnumerable<TreeViewActivityDto>)>>>(), true))
                .ReturnsAsync((categories, jobs, activities));

            // When
            var result = await _treeViewService.GetAllByUserContext();

            // Then
            result.Categories.Should().BeEmpty();
        }
    }
}
