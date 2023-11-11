using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Npgsql;

namespace Lib.DataAccess;

public class UserDataAccess : IUserDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;
    private readonly IRoleDataAccess _roleDataAccess;

    public UserDataAccess(IDataBaseManager dataBaseManager, IRoleDataAccess roleDataAccess)
    {
        _dataBaseManager = dataBaseManager;
        _roleDataAccess = roleDataAccess;
    }

    public const string UserSelectString = @"
    user_id, 
    user_name, 
    normalized_user_name, 
    email, 
    normalized_email, 
    email_confirmed, 
    password_hash, 
    security_stamp, 
    concurrency_stamp, 
    phone_number, 
    phone_number_confirmed, 
    two_factor_enabled, 
    lockout_end, 
    lockout_enabled, 
    access_failed_count, 
    profile_picture_media_id, 
    created_at, 
    modified_at,
    status
";

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken ct)
    {
        user.ConcurrencyStamp = Guid.NewGuid();
    
        const string insertQuery = @"
INSERT INTO public.user 
    (user_id, user_name, normalized_user_name, email, normalized_email, email_confirmed, 
    password_hash, security_stamp, concurrency_stamp, phone_number, phone_number_confirmed, 
    two_factor_enabled, lockout_end, lockout_enabled, access_failed_count, profile_picture_media_id, status) 
VALUES 
    (@UserId, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, 
    @PasswordHash, @SecurityStamp, @ConcurrencyStamp, @PhoneNumber, @PhoneNumberConfirmed, 
    @TwoFactorEnabled, @LockoutEnd, @LockoutEnabled, @AccessFailedCount, @ProfilePictureMediaId, 
    @Status)";
    
        ct.ThrowIfCancellationRequested();
        
        await _dataBaseManager.ExecuteAsync(insertQuery, user);
        
        return new IdentityResult();
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken ct)
    {
        const string updateQuery = @"
UPDATE public.user 
SET 
    user_name = @UserName, 
    normalized_user_name = @NormalizedUserName, 
    email = @Email, 
    normalized_email = @NormalizedEmail, 
    email_confirmed = @EmailConfirmed, 
    password_hash = @PasswordHash, 
    security_stamp = @SecurityStamp, 
    concurrency_stamp = @ConcurrencyStamp, 
    phone_number = @PhoneNumber, 
    phone_number_confirmed = @PhoneNumberConfirmed, 
    two_factor_enabled = @TwoFactorEnabled, 
    lockout_end = @LockoutEnd, 
    lockout_enabled = @LockoutEnabled, 
    access_failed_count = @AccessFailedCount, 
    profile_picture_media_id = @ProfilePictureMediaId,
    created_at = @CreatedAt, 
    modified_at = @ModifiedAt,
    status = @Status
WHERE user_id = @UserId;";
    
        var (query, parameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, user);

        ct.ThrowIfCancellationRequested();

        try
        {
            await _dataBaseManager.ExecuteAsync(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            return IdentityResult.Failed(new IdentityError { Code = e.SqlState, Description = e.Message });
        }

        return new IdentityResult();
    }

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken ct)
    {
        // should probably just use Update and set Status
        const string deleteQuery = "DELETE FROM public.user WHERE user_id = @UserId";
    
        var (query, parameters) = _dataBaseManager.WrapQueryWithConcurrencyCheck(deleteQuery, user);
        
        ct.ThrowIfCancellationRequested();
        
        try
        {
            await _dataBaseManager.ExecuteAsync(query, parameters);
        }
        catch (NpgsqlException e) when (e.SqlState == PgErrorCodes.ConcurrencyError)
        {
            return IdentityResult.Failed(new IdentityError { Code = e.SqlState, Description = e.Message });
        }
        
        return new IdentityResult();
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return null!;
        }
    
        const string selectQuery = $"SELECT {UserSelectString} FROM public.user WHERE user_id = @UserId";
        
        ct.ThrowIfCancellationRequested();
    
        return await _dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery, new { UserId = userId });
    }
    
    public Task<User> FindByIdAsync(Guid userId, CancellationToken ct) => FindByIdAsync(userId.ToString(), ct);

    public async Task<User> FindByNameAsync(string userName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return null!;
        }
    
        const string selectQuery = @$"SELECT {UserSelectString} FROM public.user WHERE normalized_user_name = @NormalizedUserName";
    
        ct.ThrowIfCancellationRequested();
        
        return await _dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery, new { NormalizedUserName = userName.Normalize() });
    }
    
    public async Task<string> GetUserIdAsync(User user, CancellationToken ct)
    {
        return (await FindByNameAsync(user.UserName, ct)).UserId.ToString();
    }

    public async Task<string> GetUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdAsync(user.UserId, ct)).UserName;
    }

    public async Task SetUserNameAsync(User user, string userName, CancellationToken ct)
    {
        var dbUser = await FindByIdAsync(user.UserId, ct);
        dbUser.UserName = userName;
        await UpdateAsync(dbUser, ct);
    }

    public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdAsync(user.UserId, ct)).NormalizedUserName;
    }

    public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken ct)
    {
        var dbUser = await FindByIdAsync(user.UserId, ct);
        dbUser.NormalizedUserName = normalizedName;
        await UpdateAsync(dbUser, ct);
    }

    public void Dispose()
    {
    }

    public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.PasswordHash = passwordHash;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.PasswordHash;
    }

    public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return !string.IsNullOrEmpty(dbUser.PasswordHash);
    }

    public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await _roleDataAccess.FindByNameAsync(roleName.Normalize(), cancellationToken);
        
        const string query = @"
insert into public.user_role (user_id, role_id) 
values (@UserId, @RoleId) on conflict (user_id, role_id) DO NOTHING;";

        cancellationToken.ThrowIfCancellationRequested();
        await _dataBaseManager.ExecuteAsync(query, new { user.UserId, dbRole.RoleId });
    }

    public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await _roleDataAccess.FindByNameAsync(roleName.Normalize(), cancellationToken);

        const string query = "DELETE FROM user_role WHERE user_id = @UserId AND role_id = @RoleId;";
        
        cancellationToken.ThrowIfCancellationRequested();        
        await _dataBaseManager.ExecuteAsync(query, new { user.UserId, dbRole.RoleId });
    }

    public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
select name from public.role r
join public.user_role ur on r.role_id = ur.role_id
where ur.user_id = @UserId
";

        return (await _dataBaseManager.QueryAsync<string>(query, new { user.UserId })).ToList();
    }

    public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await _roleDataAccess.FindByNameAsync(roleName.Normalize(), cancellationToken);
        
        const string query = @"select exists(select 1 from user_role where user_id = @UserId and role_id = @RoleId);";

        cancellationToken.ThrowIfCancellationRequested();
        return await _dataBaseManager.ExecuteScalarAsync<bool>(query, new { user.UserId, dbRole.RoleId });
    }

    public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        const string query = @$"
select
    {UserSelectString}
from public.user u
join public.user_role ur on u.user_id = ur.user_id
join public.role r on ur.role_id = r.role_id
where r.normalized_name = @NormalizedRoleName;
";
        
        cancellationToken.ThrowIfCancellationRequested();
        return (await _dataBaseManager.QueryAsync<User>(query, new { NormalizedRoleName = roleName.Normalize() }))
            .ToList();
    }

    public async Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.Email = user.Email;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.Email;
    }

    public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.EmailConfirmed;
    }

    public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.EmailConfirmed = true;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(normalizedEmail))
        {
            return null!;
        }
    
        const string selectQuery = $"SELECT {UserSelectString} FROM public.user WHERE normalized_email = @NormalizedEmail";
        
        cancellationToken.ThrowIfCancellationRequested();

        return await _dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery,
            new { NormalizedEmail = normalizedEmail });
    }

    
    
    public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.NormalizedEmail;
    }

    public async Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.NormalizedEmail = normalizedEmail;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.LockoutEnd;
    }

    public async Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.LockoutEnd = lockoutEnd?.UtcDateTime;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
UPDATE public.user SET access_failed_count = access_failed_count + 1
WHERE user_id = @UserId 
RETURNING access_failed_count;";

        return await _dataBaseManager.ExecuteScalarAsync<int>(query, new { user.UserId });
    }

    public async Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
UPDATE public.user SET access_failed_count = 0
WHERE user_id = @UserId;";

        await _dataBaseManager.ExecuteAsync(query, new { user.UserId });
    }

    public async Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.AccessFailedCount;
    }

    public async Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.LockoutEnabled;
    }

    public async Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.LockoutEnabled = enabled;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.PhoneNumber = phoneNumber;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.PhoneNumber;
    }

    public async Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.PhoneNumberConfirmed;
    }

    public async Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.PhoneNumberConfirmed = confirmed;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        dbUser.SecurityStamp = stamp;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdAsync(user.UserId, cancellationToken);
        return dbUser.SecurityStamp;
    }

    public async Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}