using FluentAssertions;
using Lib.DataAccess;
using Lib.Exceptions;
using Lib.Models;
using Lib.Services;
using Moq;
using UnitTest.Fakes.Models;

namespace UnitTest.Services;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryDataAccess> _categoryDataAccessMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly ICategoryService _categoryService;

    public CategoryServiceTests()
    {
        _categoryDataAccessMock = new Mock<ICategoryDataAccess>();
        _userContextMock = new Mock<IUserContext>();
        _categoryService = new CategoryService(_categoryDataAccessMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnCategory_WhenInsertSucceeds()
    {
        // Given
        var model = new CategoryFaker().Generate();
        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _categoryDataAccessMock.Setup(cda => cda.Create(It.IsAny<Category>())).ReturnsAsync(model);

        // When
        var result = await _categoryService.Create(model.Name, model.Description);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Create_WithCategoryModel_ShouldReturnCategory_WhenInsertSucceeds()
    {
        // Given
        var model = new CategoryFaker().Generate();
        _userContextMock.Setup(uc => uc.UserId).Returns(Guid.NewGuid());
        _categoryDataAccessMock.Setup(cda => cda.Create(It.IsAny<Category>())).ReturnsAsync(model);

        // When
        var result = await _categoryService.Create(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedCategory_WhenUpdateSucceeds()
    {
        // Given
        var model = new CategoryFaker().Generate();
        var current = new CategoryFaker().Generate();
        current.CategoryId = model.CategoryId;
        current.ConcurrencyStamp = model.ConcurrencyStamp;

        _categoryDataAccessMock.Setup(cda => cda.Get(model.CategoryId)).ReturnsAsync(current);
        _categoryDataAccessMock.Setup(cda => cda.Update(It.IsAny<Category>())).ReturnsAsync(model);

        // When
        var result = await _categoryService.Update(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldThrowConcurrencyStampMismatchException_WhenStampsDoNotMatch()
    {
        // Given
        var model = new CategoryFaker().Generate();
        var current = new CategoryFaker().Generate();
        current.CategoryId = model.CategoryId;
        current.ConcurrencyStamp = Guid.NewGuid();

        _categoryDataAccessMock.Setup(cda => cda.Get(model.CategoryId)).ReturnsAsync(current);

        // When
        Func<Task> act = async () => await _categoryService.Update(model);

        // Then
        await act.Should().ThrowAsync<ConcurrencyStampMismatchException>();
    }

    [Fact]
    public async Task Get_ShouldReturnCategory_WhenExists()
    {
        // Given
        var model = new CategoryFaker().Generate();

        _categoryDataAccessMock.Setup(cda => cda.Get(model.CategoryId)).ReturnsAsync(model);

        // When
        var result = await _categoryService.Get(model.CategoryId);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task GetPaged_ShouldReturnPagedCategories_WhenExists()
    {
        // Given
        var categories = new List<Category>
        {
            new CategoryFaker().Generate(),
            new CategoryFaker().Generate()
        };

        _categoryDataAccessMock.Setup(cda => cda.GetPaged(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(categories);

        // When
        var result = await _categoryService.GetPaged(0, 2);

        // Then
        result.Should().BeEquivalentTo(categories);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var categoryId = Guid.NewGuid();

        _categoryDataAccessMock.Setup(cda => cda.Delete(categoryId)).ReturnsAsync(true);

        // When
        var result = await _categoryService.Delete(categoryId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var categoryId = Guid.NewGuid();

        _categoryDataAccessMock.Setup(cda => cda.Delete(categoryId)).ReturnsAsync(false);

        // When
        var result = await _categoryService.Delete(categoryId);

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnCategories_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var categories = new List<Category>
        {
            new CategoryFaker().Generate(),
            new CategoryFaker().Generate()
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _categoryDataAccessMock.Setup(cda => cda.GetAllByUserContext(true)).ReturnsAsync(categories);

        // When
        var result = await _categoryService.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(categories);
    }
}