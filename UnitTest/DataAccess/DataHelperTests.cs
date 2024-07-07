using FluentAssertions;
using Lib.DataAccess;

namespace UnitTest.DataAccess;

public class DataHelperTests
{
    [Theory]
    [InlineData("testuser", "TESTUSER")]
    [InlineData("TestUser", "TESTUSER")]
    [InlineData("TESTUSER", "TESTUSER")]
    [InlineData(" testuser ", " TESTUSER ")]
    [InlineData("TeSt UsEr", "TEST USER")]
    public void Normalize_ShouldReturnUpperCaseAndNormalizedString_WhenValueIsValid(string input, string expected)
    {
        // Given
        // (input and expected are provided by the Theory attribute)

        // When
        var result = DataHelper.Normalize(input);

        // Then
        result.Should().Be(expected);
    }

    [Fact]
    public void Normalize_ShouldThrowArgumentNullException_WhenValueIsNull()
    {
        // Given
        string input = null;

        // When
        Action act = () => DataHelper.Normalize(input);

        // Then
        act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'value')");
    }

    [Fact]
    public void Normalize_ShouldThrowArgumentNullException_WhenValueIsEmpty()
    {
        // Given
        string input = string.Empty;

        // When
        Action act = () => DataHelper.Normalize(input);

        // Then
        act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'value')");
    }
}