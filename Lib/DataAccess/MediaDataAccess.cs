using Lib.Models;
using Lib.Services;
using Npgsql;

namespace Lib.DataAccess;

public class MediaDataAccess(IDataBaseManager dataBaseManager, IUserContext userContext) : IMediaDataAccess
{
    public async Task<Media> Create(Media media)
    {
        const string insertQuery = @"
INSERT INTO public.media
    (media_id, activity_id, original_filename, extension, mime_type, size, storage_path, hash, metadata, status, created_at, modified_at, user_id) 
VALUES 
    (@MediaId, @ActivityId, @OriginalFilename, @Extension, @MimeType, @Size, @StoragePath, @Hash, @Metadata, @Status, @CreatedAt, @ModifiedAt, @UserId)
RETURNING *;";

        return await dataBaseManager.QuerySingleOrDefaultAsync<Media>(insertQuery, media);
    }

    public async Task<Media> Update(Media media)
    {
        const string updateQuery = @"
UPDATE public.media SET
    activity_id = @ActivityId,
    original_filename = @OriginalFilename,
    extension = @Extension,
    mime_type = @MimeType,
    size = @Size,
    storage_path = @StoragePath,
    hash = @Hash,
    metadata = @Metadata,
    status = @Status,
    modified_at = @ModifiedAt,
    user_id = @UserId
WHERE media_id = @MediaId;";
        
        var (query, parameters) = dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, media);

        try
        {
            return await dataBaseManager.QuerySingleOrDefaultAsync<Media>(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            
            throw;
        }
    }
    
    public async Task<List<Media>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";

        const string pagedQuery = @"
WITH ranked_media AS (
    SELECT *,
    ROW_NUMBER() OVER (ORDER BY created_at {0}) AS rn
    FROM public.media
)
SELECT
    media_id,
    activity_id,
    original_filename,
    extension,
    mime_type,
    size,
    storage_path,
    hash,
    metadata,
    status,
    created_at,
    modified_at,
    user_id
FROM ranked_media
WHERE rn > @StartRow AND rn <= @EndRow;
";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { StartRow = startRow, EndRow = startRow + count };

        return (await dataBaseManager.QueryAsync<Media>(finalQuery, parameters)).ToList();
    }

    public async Task<Media> Get(Guid mediaId)
    {
        const string selectQuery = @"
SELECT 
    media_id,
    activity_id,
    original_filename,
    extension,
    mime_type,
    size,
    storage_path,
    hash,
    metadata,
    status,
    created_at,
    modified_at,
    user_id
FROM 
    public.media
WHERE 
    media_id = @MediaId";

        return await dataBaseManager.QueryFirstOrDefaultAsync<Media>(selectQuery, new { MediaId = mediaId });
    }

    public async Task<IEnumerable<Media>> GetAllByUserContext(bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";
        const string query = @"
SELECT 
    media_id,
    activity_id,
    original_filename,
    extension,
    mime_type,
    size,
    storage_path,
    hash,
    metadata,
    status,
    created_at,
    modified_at,
    user_id
FROM 
    public.media
WHERE 
    user_id = @UserId
ORDER BY created_at {0};
";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(query, orderByDirection);
        
        return await dataBaseManager.QueryAsync<Media>(finalQuery, new { userContext.UserId });
    }

    public async Task<bool> Delete(Guid mediaId)
    {
        const string query = @"
DELETE FROM
    public.media
WHERE
    media_id = @MediaId AND user_id = @UserId;";

        return await dataBaseManager.ExecuteAsync(query, new { userContext.UserId, mediaId }) > 0;
    }
}