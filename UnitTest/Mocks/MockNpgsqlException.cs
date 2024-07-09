using Npgsql;

namespace UnitTest.Mocks;

/// <summary>
/// NpgsqlException that allows setting SqlState for testing
/// </summary>
public class MockNpgsqlException(string sqlState) : NpgsqlException
{
    public override string SqlState => sqlState;
}