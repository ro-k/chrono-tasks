using Dapper;
using Lib.Models;

namespace Lib.DataAccess;

public interface IDataBaseManager
{
    Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null);
    
    /// <summary>
    /// QuerySingleOrDefault
    /// </summary>
    Task<T> QuerySingleOrDefaultAsync<T>(string query, object? parameters = null);

    Task<T> QueryFirstOrDefaultAsync<T>(string query, object? parameters = null);
    Task<int> ExecuteAsync(string query, object? parameters = null);
    (string, DynamicParameters) WrapQueryWithConcurrencyCheck(string query, IHasConcurrencyStamp baseParameters);
}