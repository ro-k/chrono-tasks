using Lib.Exceptions;
using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Npgsql;
// ReSharper disable UseRawString

namespace Lib.DataAccess;

public class RoleDataAccess(IDataBaseManager dataBaseManager) : IRoleDataAccess
{
    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken ct)
    {
        // use name as back up
        role.NormalizedName = string.IsNullOrEmpty(role.NormalizedName) ? role.Name.Normalize() : role.NormalizedName;

        role.ConcurrencyStamp = Guid.NewGuid();
        
        const string insertQuery = @"
INSERT INTO role
    (role_id, name, normalized_name, concurrency_stamp) 
VALUES 
    (@RoleId, @Name, @NormalizedName, @ConcurrencyStamp)";
        
        ct.ThrowIfCancellationRequested();
        
        await dataBaseManager.ExecuteAsync(insertQuery, role);

        return new IdentityResult();
    }

    public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken ct)
    {
        const string updateQuery = @"
UPDATE role SET 
    name = @Name,
    normalized_name = @NormalizedName,
    concurrency_stamp = @ConcurrencyStamp
WHERE role_id = @RoleId;";
        
        var (query, parameters) = dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, role);

        ct.ThrowIfCancellationRequested();

        try
        {
            await dataBaseManager.ExecuteAsync(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            return IdentityResult.Failed(new IdentityError { Code = e.SqlState, Description = e.Message });
        }

        return new IdentityResult();
    }

    public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken ct)
    {
        const string deleteQuery = "DELETE FROM role WHERE role_id = @RoleId;";

        var (query, parameters) = dataBaseManager.WrapQueryWithConcurrencyCheck(deleteQuery, role);
        
        ct.ThrowIfCancellationRequested();
        
        try
        {
            await dataBaseManager.ExecuteAsync(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            return IdentityResult.Failed(new IdentityError { Code = e.SqlState, Description = e.Message });
        }
        
        return new IdentityResult();
    }

    public async Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
    {
        return (await FindByNameOrThrowAsync(role.Name, cancellationToken)).RoleId.ToString();
    }

    public async Task<string?> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return (await FindByNameOrThrowAsync(role.RoleId.ToString(), cancellationToken)).Name;
    }

    public async Task SetRoleNameAsync(Role role, string? roleName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(roleName)) throw new ArgumentNullException(nameof(roleName));
        
        var dbRole = await FindByNameOrThrowAsync(role.RoleId.ToString(), cancellationToken);
        dbRole.Name = roleName;
        
        await UpdateAsync(dbRole, cancellationToken);
    }

    public async Task<string?> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return (await FindByNameOrThrowAsync(role.RoleId.ToString(), cancellationToken)).NormalizedName;
    }

    public async Task SetNormalizedRoleNameAsync(Role role, string? normalizedName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(normalizedName)) throw new ArgumentNullException(nameof(normalizedName));
        
        var dbRole = await FindByNameOrThrowAsync(role.RoleId.ToString(), cancellationToken);
        dbRole.NormalizedName = normalizedName;
        await UpdateAsync(dbRole, cancellationToken);
    }


    public async Task<Role?> FindByIdAsync(string roleId, CancellationToken ct)
    {
        const string selectQuery = @"
SELECT role_id, 
       name, 
       normalized_name, 
       concurrency_stamp 
FROM role
WHERE role_id = @RoleId;";

        return await dataBaseManager.QuerySingleOrDefaultAsync<Role>(selectQuery, new { RoleId = Guid.Parse(roleId) });
    }

    public async Task<Role> FindByNameOrThrowAsync(string roleName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(roleName)) throw new ArgumentNullException(nameof(roleName));

        var dbRole = await FindByNameAsync(roleName, ct);

        if (dbRole == null) throw new RoleNotFoundException();

        return dbRole;
    }

    public async Task<Role?> FindByNameAsync(string roleName, CancellationToken ct)
    {
        const string selectQuery = @"
SELECT role_id, 
       name, 
       normalized_name, 
       concurrency_stamp 
FROM role
WHERE normalized_name = @NormalizedRoleName";
        
        ct.ThrowIfCancellationRequested();

        return await dataBaseManager.QuerySingleOrDefaultAsync<Role>(selectQuery, new { NormalizedRoleName = roleName.Normalize() });
    }

    public void Dispose()
    {
    }
}