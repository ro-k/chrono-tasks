using System.Diagnostics.CodeAnalysis;

namespace Lib.Exceptions;

[ExcludeFromCodeCoverage]
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message){}

    public BadRequestException(IEnumerable<string> messages) : base(string.Join(", ", messages))
    {
    }
}