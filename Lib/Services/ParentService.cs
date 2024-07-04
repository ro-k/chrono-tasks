using Lib.DataAccess;

namespace Lib.Services;

public class ParentService(IParentDataAccess parentDataAccess) : IParentService
{
    public async Task<IEnumerable<Guid>> GetAllByUserContext()
    {
        return await parentDataAccess.GetAllByUserContext();
    }
    
}