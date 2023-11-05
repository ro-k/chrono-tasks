using Lib.Models;

namespace Lib.DataAccess;

public class ClaimsDataAccess : IClaimDataAccess
{
    private IDataBaseManager _dataBaseManager;

    public ClaimsDataAccess(IDataBaseManager dataBaseManager)
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
INSERT INTO claims 
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
UPDATE claims 
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
        throw new NotImplementedException();
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
FROM claims 
WHERE 
    claim_id = @ClaimId";
    
        return await _dataBaseManager.QuerySingleOrDefaultAsync<Claim>(selectQuery, new { ClaimId = claimId });
    }

}