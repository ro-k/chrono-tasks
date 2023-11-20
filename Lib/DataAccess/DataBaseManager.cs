using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Dapper;
using Lib.Models;
using Microsoft.Extensions.Options;

namespace Lib.DataAccess;

public class DataBaseManager : IDataBaseManager
{
    private readonly string _connectionString;

    public DataBaseManager(IOptions<AppSettings> appSettings)
    {
        _connectionString = appSettings.Value.ConnectionString!;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.QueryAsync<T>(query, parameters);
    }
    
    public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.QuerySingleOrDefaultAsync<T>(query, parameters);
    }
    
    public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters);
    }
    
    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.ExecuteAsync(query, parameters);
    }

    public async Task<T> ExecuteScalarAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return await dbConnection.ExecuteScalarAsync<T>(query, parameters);
    }

    public (string, DynamicParameters) WrapQueryWithConcurrencyCheck(string query, IHasConcurrencyStamp baseParameters)
    {
        var whereRegex = new Regex(@"\bWHERE\b", RegexOptions.IgnoreCase);
        var oldConcurrencyStamp = baseParameters.ConcurrencyStamp;
        baseParameters.ConcurrencyStamp = Guid.NewGuid();
        var parameters = new DynamicParameters(baseParameters);
        parameters.AddDynamicParams(new { OldConcurrencyStamp = oldConcurrencyStamp });

        var appendedQuery = whereRegex.IsMatch(query)
            ? Regex.Replace(query, @"\bWHERE\b", $"WHERE concurrency_stamp = @OldConcurrencyStamp AND ",
                RegexOptions.IgnoreCase)
            : $"{query} WHERE concurrency_stamp = @OldConcurrencyStamp";

        appendedQuery = appendedQuery.TrimEnd(' ', ';');

        appendedQuery = @$"
DO $$ 
BEGIN 

{appendedQuery}
RETURNING *;

IF NOT FOUND THEN 
    RAISE EXCEPTION 'Concurrency conflict' USING ERRCODE = 'P0001';
END IF;
END $$;
";

        return (appendedQuery, parameters);
    }
}