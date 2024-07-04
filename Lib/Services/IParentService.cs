namespace Lib.Services;

public interface IParentService
{
    Task<IEnumerable<Guid>> GetAllByUserContext();
}