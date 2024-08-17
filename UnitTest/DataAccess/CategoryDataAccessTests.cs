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

public class CategoryDataAccessTests
{
    private readonly Mock<IDataBaseManager> _dataBaseManagerMock;
    private readonly Mock<IUserContext> _userContextMock;
    private readonly ICategoryDataAccess _categoryDataAccess;

    public CategoryDataAccessTests()
    {
        _dataBaseManagerMock = new Mock<IDataBaseManager>();
        _userContextMock = new Mock<IUserContext>();
        _categoryDataAccess = new CategoryDataAccess(_dataBaseManagerMock.Object, _userContextMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnCategory_WhenInsertSucceeds()
    {
        // Given
        var model = new CategoryFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.QuerySingleOrDefaultAsync<Category>(It.IsAny<string>(), model))
            .ReturnsAsync(model);

        // When
        var result = await _categoryDataAccess.Create(model);

        // Then
        result.Should().BeEquivalentTo(model);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedCategory_WhenUpdateSucceeds()
    {
        // Given
        var model = new CategoryFaker().Generate();

        var returnedCategory = model;
        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Category>()))
            .Returns((model.CategoryId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Category>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedCategory);

        // When
        var result = await _categoryDataAccess.Update(model);

        // Then
        result.Should().BeEquivalentTo(returnedCategory);
    }

    [Fact]
    public async Task Update_ShouldRethrow()
    {
        // Given
        var model = new CategoryFaker().Generate();

        _dataBaseManagerMock.Setup(dbm => dbm.WrapQueryWithConcurrencyCheck(It.IsAny<string>(), It.IsAny<Media>()))
            .Returns((model.CategoryId.ToString(), new DynamicParameters()));
        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Category>(It.IsAny<string>(), It.IsAny<object>()))
            .ThrowsAsync(new MockNpgsqlException(PgErrorCodes.ConcurrencyError));

        // When
        var act = async () => await _categoryDataAccess.Update(model);

        // Then
        await act.Should().ThrowAsync<NpgsqlException>();
    }

    [Fact]
    public async Task Get_ShouldReturnCategory_WhenExists()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var returnedCategory = new Category
        {
            CategoryId = categoryId,
            UserId = Guid.NewGuid()
        };

        _dataBaseManagerMock
            .Setup(dbm => dbm.QuerySingleOrDefaultAsync<Category>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(returnedCategory);

        // When
        var result = await _categoryDataAccess.Get(categoryId);

        // Then
        result.Should().BeEquivalentTo(returnedCategory);
    }

    [Fact]
    public async Task GetAllByUserContext_ShouldReturnCategories_WhenExists()
    {
        // Given
        var userId = Guid.NewGuid();
        var categories = new List<Category>
        {
            new() { CategoryId = Guid.NewGuid(), UserId = userId },
            new() { CategoryId = Guid.NewGuid(), UserId = userId }
        };

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Category>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(categories);

        // When
        var result = await _categoryDataAccess.GetAllByUserContext();

        // Then
        result.Should().BeEquivalentTo(categories);
    }

    [Fact]
    public async Task Delete_ShouldReturnTrue_WhenDeleteSucceeds()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);

        // When
        var result = await _categoryDataAccess.Delete(categoryId);

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenDeleteFails()
    {
        // Given
        var categoryId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        _userContextMock.Setup(uc => uc.UserId).Returns(userId);
        _dataBaseManagerMock.Setup(dbm => dbm.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(0);

        // When
        var result = await _categoryDataAccess.Delete(categoryId);

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetPaged_ShouldReturnPagedCategories_WhenExists()
    {
        // Given
        var startRow = 0;
        var count = 2;
        var categoryList = new List<Category>
        {
            new() { CategoryId = Guid.NewGuid() },
            new() { CategoryId = Guid.NewGuid() }
        };

        _dataBaseManagerMock.Setup(dbm => dbm.QueryAsync<Category>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(categoryList);

        // When
        var result = await _categoryDataAccess.GetPaged(startRow, count);

        // Then
        result.Should().BeEquivalentTo(categoryList);
    }
}