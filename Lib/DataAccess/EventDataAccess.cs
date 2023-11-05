using Lib.Models;

namespace Lib.DataAccess;

public class EventDataAccess : IEventDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    
    public EventDataAccess(IDataBaseManager dataBaseManager)
    {
        _dataBaseManager = dataBaseManager;
    }

    public async Task Create(Event model)
    {
        const string insertQuery = @"
INSERT INTO public.event (
    event_id, 
    start_time, 
    end_time, 
    name, 
    description, 
    created_at, 
    modified_at, 
    user_id, 
    concurrency_stamp
) VALUES (
    @EventId, 
    @StartTime, 
    @EndTime, 
    @Name, 
    @Description, 
    @CreatedAt, 
    @ModifiedAt, 
    @UserId, 
    @ConcurrencyStamp
)";

        await _dataBaseManager.ExecuteAsync(insertQuery, new {
            model.EventId,
            model.StartTime,
            model.EndTime,
            model.Name,
            model.Description,
            model.CreatedAt,
            model.ModifiedAt,
            model.UserId,
            model.ConcurrencyStamp
        });
    }

    public async Task Update(Event model)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Event>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        throw new NotImplementedException();
    }

    public async Task<Event> Get(Guid id)
    {
        throw new NotImplementedException();
    }
}