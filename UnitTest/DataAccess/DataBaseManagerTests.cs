using System.Data;
using Dapper;
using FluentAssertions;
using Lib.DataAccess;
using Lib.Models;
using Moq;
using Moq.Dapper;

namespace UnitTest.DataAccess;

public class DataBaseManagerTests
{
    private readonly Mock<IDbConnection> _dbConnectionMock;
    private readonly IDataBaseManager _dataBaseManager;

    public DataBaseManagerTests()
    {
        _dbConnectionMock = new Mock<IDbConnection>();
        _dataBaseManager = new DataBaseManager(() => _dbConnectionMock.Object);
    }

    [Fact]
    public async Task QueryAsync_ShouldReturnExpectedResults()
    {
        // Given
        var query = "SELECT * FROM public.category";
        var expectedCategories = new List<Category>
        {
            new Category { CategoryId = Guid.NewGuid(), Name = "Category 1" },
            new Category { CategoryId = Guid.NewGuid(), Name = "Category 2" }
        };

        _dbConnectionMock
            .SetupDapperAsync(db => db.QueryAsync<Category>(It.IsAny<string>(), null, null, null, null))
            .ReturnsAsync(expectedCategories);

        // When
        var result = await _dataBaseManager.QueryAsync<Category>(query);

        // Then
        result.Should().BeEquivalentTo(expectedCategories);
    }

    [Fact]
    public async Task QuerySingleOrDefaultAsync_ShouldReturnExpectedResult()
    {
        // Given
        var query = "SELECT * FROM public.category WHERE category_id = @CategoryId";
        var categoryId = Guid.NewGuid();
        var expectedCategory = new Category { CategoryId = categoryId, Name = "Category 1" };

        _dbConnectionMock.SetupDapperAsync(db =>
                db.QuerySingleOrDefaultAsync<Category>(query, new { CategoryId = categoryId }, null, null, null))
            .ReturnsAsync(expectedCategory);

        // When
        var result =
            await _dataBaseManager.QuerySingleOrDefaultAsync<Category>(query, new { CategoryId = categoryId });

        // Then
        result.Should().BeEquivalentTo(expectedCategory);
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnExpectedResult()
    {
        // Given
        var query = "UPDATE public.category SET name = @Name WHERE category_id = @CategoryId";
        var parameters = new { CategoryId = Guid.NewGuid(), Name = "Updated Name" };

        _dbConnectionMock.SetupDapperAsync(db => db.ExecuteAsync(query, parameters, null, null, null))
            .ReturnsAsync(1);

        // When
        var result = await _dataBaseManager.ExecuteAsync(query, parameters);

        // Then
        result.Should().Be(1);
    }

    [Fact]
    public Task WrapQueryWithConcurrencyCheck_ShouldReturnExpectedQueryAndParameters()
    {
        // Given
        var query = "UPDATE public.category SET name = @Name WHERE category_id = @CategoryId";
        var concurrencyStamp = Guid.NewGuid();
        var baseParameters = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Test Category",
            ConcurrencyStamp = concurrencyStamp,
        };

        // When
        var (resultQuery, resultParameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(query, baseParameters);

        // Then
        const string expectedQuery = @"
UPDATE public.category SET name = @Name WHERE concurrency_stamp = @OldConcurrencyStamp AND category_id = @CategoryId
RETURNING *;
";
        resultQuery.Should().Be(expectedQuery);

        resultParameters.Get<string>("OldConcurrencyStamp").Should().Be(concurrencyStamp.ToString());
        baseParameters.ConcurrencyStamp.Should().NotBe(concurrencyStamp);

        return Task.CompletedTask;
    }

    [Fact]
    public async Task QueryFirstOrDefaultAsync_ShouldReturnExpectedResult()
    {
        // Given
        var query = "SELECT * FROM public.category WHERE category_id = @CategoryId";
        var categoryId = Guid.NewGuid();
        var expectedCategory = new Category { CategoryId = categoryId, Name = "Category 1" };

        _dbConnectionMock.SetupDapperAsync(db =>
                db.QueryFirstOrDefaultAsync<Category>(query, new { CategoryId = categoryId }, null, null, null))
            .ReturnsAsync(expectedCategory);

        // When
        var result =
            await _dataBaseManager.QueryFirstOrDefaultAsync<Category>(query, new { CategoryId = categoryId });

        // Then
        result.Should().BeEquivalentTo(expectedCategory);
    }
}