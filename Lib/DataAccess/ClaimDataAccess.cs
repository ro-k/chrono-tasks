using Lib.Models;

namespace Lib.DataAccess;

public class ClaimDataAccess : IClaimDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;

    public ClaimDataAccess(IDataBaseManager dataBaseManager)
    {
        _dataBaseManager = dataBaseManager;
    }

    public async Task Create(Claim claim)
    {
        if (claim == null)
        {
            throw new ArgumentNullException(nameof(claim));
        }
    
        const string insertQuery = @"
INSERT INTO claim
    (claim_id, role_id, type, value) 
VALUES 
    (@ClaimId, @RoleId, @Type, @Value)";
    
        await _dataBaseManager.ExecuteAsync(insertQuery, claim);
    }


    public async Task Update(Claim claim)
    {
        if (claim == null)
        {
            throw new ArgumentNullException(nameof(claim));
        }
    
        const string updateQuery = @"
UPDATE claim 
SET 
    role_id = @RoleId, 
    type = @Type, 
    value = @Value
WHERE 
    claim_id = @ClaimId";
    
        await _dataBaseManager.ExecuteAsync(updateQuery, claim);
    }

    public async Task<List<Claim>> GetPaged(int startRow = 0, int count = 100, bool descending = true)
    {
        var orderByDirection = descending ? "DESC" : "ASC";

        const string pagedQuery = @"
WITH ranked_claims AS (
    SELECT *,
    ROW_NUMBER() OVER (ORDER BY claim_id {0}) AS rn
    FROM claim
)
SELECT
    claim_id,
    role_id,
    type,
    value
FROM ranked_claims
WHERE rn > @StartRow AND rn <= @EndRow
ORDER BY claim_id {0};";

        // Formatted query to include dynamic order by direction
        var finalQuery = string.Format(pagedQuery, orderByDirection);

        var parameters = new { StartRow = startRow, EndRow = startRow + count };

        return (await _dataBaseManager.QueryAsync<Claim>(finalQuery, parameters)).ToList();
    }


    public async Task<Claim> Get(Guid claimId)
    {
        if (claimId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(claimId));
        }
    
        const string selectQuery = @"
SELECT 
    claim_id, 
    role_id, 
    type, 
    value
FROM claim
WHERE 
    claim_id = @ClaimId";
    
        return await _dataBaseManager.QuerySingleOrDefaultAsync<Claim>(selectQuery, new { ClaimId = claimId });
    }

}