namespace Lib.DataAccess;

public interface IBaseDataAccess<T>
{
    Task Create(T model);

    Task Update(T model);

    Task<List<T>> GetPaged(int startRow = 0, int count = 100, bool descending = true);

    Task<T> Get(Guid id);
}