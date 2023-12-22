namespace Lib.DataAccess;

public interface IBaseDataAccess<T>
{
    Task<T> Create(T model);

    Task<T> Update(T model);

    // TODO: need to send back total records at some point for proper paging
    Task<List<T>> GetPaged(int startRow = 0, int count = 100, bool descending = true);

    Task<T> Get(Guid id);

    Task<IEnumerable<T>> GetAllByUserContext(bool descending = true);

    Task<bool> Delete(Guid id);
}