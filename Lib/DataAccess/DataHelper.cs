namespace Lib.DataAccess;

public static class DataHelper
{
    public static string Normalize(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));

        var upperCaseUsername = value.ToUpperInvariant().Normalize();
        return upperCaseUsername;
    }
}