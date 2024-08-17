using FluentAssertions;
using Lib.DataAccess;
using Lib.Services;
using Moq;

namespace UnitTest.Services;

public class ParentServiceTests
{
    private readonly Mock<IParentDataAccess> _parentDataAccessMock;
    private readonly IParentService _parentService;

    public ParentServiceTests()
    {
        _parentDataAccessMock = new Mock<IParentDataAccess>();
        _parentService = new ParentService(_parentDataAccessMock.Object);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnGuids_WhenExists()
    {
        // Given
        var guids = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };

        _parentDataAccessMock.Setup(pda => pda.GetAllByUserContext()).ReturnsAsync(guids);

        // When
        var result = await _parentService.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(guids);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnEmpty_WhenNoGuidsExist()
    {
        // Given
        _parentDataAccessMock.Setup(pda => pda.GetAllByUserContext()).ReturnsAsync(new List<Guid>());

        // When
        var result = await _parentService.GetAllByUserContext();

        // Then
        result.Should().BeEmpty();
    }
}