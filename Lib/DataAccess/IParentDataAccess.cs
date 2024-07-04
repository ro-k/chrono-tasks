namespace Lib.DataAccess;

public interface IParentDataAccess
{
    Task<IEnumerable<Guid>> GetAllByUserContext();
}