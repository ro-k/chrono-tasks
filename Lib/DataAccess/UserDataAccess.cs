using Lib.Exceptions;
using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Npgsql;
// ReSharper disable UseRawString

namespace Lib.DataAccess;

public class UserDataAccess(IDataBaseManager dataBaseManager, IRoleDataAccess roleDataAccess)
    : IUserDataAccess
{
    private const string UserSelectString = @"
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
        
        await dataBaseManager.ExecuteAsync(insertQuery, user);
        
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
    
        var (query, parameters) = dataBaseManager.WrapQueryWithConcurrencyCheck(updateQuery, user);

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

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken ct)
    {
        // should probably just use Update and set Status
        const string deleteQuery = "DELETE FROM public.user WHERE user_id = @UserId";
    
        var (query, parameters) = dataBaseManager.WrapQueryWithConcurrencyCheck(deleteQuery, user);
        
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

    public async Task<User?> FindByIdAsync(string userId, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }
    
        const string selectQuery = $"SELECT {UserSelectString} FROM public.user WHERE user_id = @UserId";
        
        ct.ThrowIfCancellationRequested();
    
        return await dataBaseManager.QuerySingleOrDefaultAsync<User?>(selectQuery, new { UserId = userId });
    }

    private async Task<User> FindByIdOrThrowAsync(Guid userId, CancellationToken ct)
    {
        var dbUser = await FindByIdAsync(userId.ToString(), ct);
        if (dbUser == null) throw new UserNotFoundException();
        return dbUser;
    }

    private async Task<User> FindByUserNameOrThrowAsync(string userName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
        
        var dbUser = await FindByNameAsync(userName, ct);

        if (dbUser == null) throw new UserNotFoundException();

        return dbUser;
    }

    public async Task<User?> FindByNameAsync(string userName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return null;
        }
    
        const string selectQuery = $"SELECT {UserSelectString} FROM public.user WHERE normalized_user_name = @NormalizedUserName";
    
        ct.ThrowIfCancellationRequested();
        
        return await dataBaseManager.QuerySingleOrDefaultAsync<User?>(selectQuery, new { NormalizedUserName = userName.Normalize() });
    }
    
    public async Task<string> GetUserIdAsync(User user, CancellationToken ct)
    {
        return (await FindByUserNameOrThrowAsync(user.UserName, ct)).UserId.ToString();
    }

    public async Task<string?> GetUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdOrThrowAsync(user.UserId, ct)).UserName;
    }

    public async Task SetUserNameAsync(User user, string? userName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
        
        var dbUser = await FindByIdOrThrowAsync(user.UserId, ct);
        
        dbUser.UserName = userName;
        await UpdateAsync(dbUser, ct);
    }

    public async Task<string?> GetNormalizedUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdOrThrowAsync(user.UserId, ct)).NormalizedUserName;
    }

    public async Task SetNormalizedUserNameAsync(User user, string? normalizedName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(normalizedName)) throw new ArgumentNullException(nameof(normalizedName));
        
        var dbUser = await FindByIdOrThrowAsync(user.UserId, ct);
        dbUser.NormalizedUserName = normalizedName;
        await UpdateAsync(dbUser, ct);
    }

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task SetPasswordHashAsync(User user, string? passwordHash, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(passwordHash)) throw new ArgumentNullException(nameof(passwordHash));
        
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.PasswordHash = passwordHash;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string?> GetPasswordHashAsync(User user, CancellationToken cancellationToken) =>
        (await FindByIdOrThrowAsync(user.UserId, cancellationToken)).PasswordHash;

    public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return !string.IsNullOrEmpty(dbUser.PasswordHash);
    }

    public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await roleDataAccess.FindByNameOrThrowAsync(roleName.Normalize(), cancellationToken);
        
        const string query = @"
insert into public.user_role (user_id, role_id) 
values (@UserId, @RoleId) on conflict (user_id, role_id) DO NOTHING;";

        cancellationToken.ThrowIfCancellationRequested();
        await dataBaseManager.ExecuteAsync(query, new { user.UserId, dbRole.RoleId });
    }

    public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await roleDataAccess.FindByNameOrThrowAsync(roleName.Normalize(), cancellationToken);

        const string query = "DELETE FROM user_role WHERE user_id = @UserId AND role_id = @RoleId;";
        
        cancellationToken.ThrowIfCancellationRequested();        
        await dataBaseManager.ExecuteAsync(query, new { user.UserId, dbRole.RoleId });
    }

    public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
select name from public.role r
join public.user_role ur on r.role_id = ur.role_id
where ur.user_id = @UserId
";

        return (await dataBaseManager.QueryAsync<string>(query, new { user.UserId })).ToList();
    }

    public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        var dbRole = await roleDataAccess.FindByNameOrThrowAsync(roleName.Normalize(), cancellationToken);
        
        const string query = @"select exists(select 1 from user_role where user_id = @UserId and role_id = @RoleId);";

        cancellationToken.ThrowIfCancellationRequested();
        return await dataBaseManager.ExecuteScalarAsync<bool>(query, new { user.UserId, dbRole.RoleId });
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
        return (await dataBaseManager.QueryAsync<User>(query, new { NormalizedRoleName = roleName.Normalize() }))
            .ToList();
    }

    public async Task SetEmailAsync(User user, string? email, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.Email = user.Email;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string?> GetEmailAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.Email;
    }

    public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.EmailConfirmed;
    }

    public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.EmailConfirmed = true;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<User?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(normalizedEmail))
        {
            return null!;
        }
    
        const string selectQuery = $"SELECT {UserSelectString} FROM public.user WHERE normalized_email = @NormalizedEmail";
        
        cancellationToken.ThrowIfCancellationRequested();

        return await dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery,
            new { NormalizedEmail = normalizedEmail });
    }

    
    
    public async Task<string?> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.NormalizedEmail;
    }

    public async Task SetNormalizedEmailAsync(User user, string? normalizedEmail, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(normalizedEmail)) throw new ArgumentNullException(nameof(normalizedEmail));
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.NormalizedEmail = normalizedEmail;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.LockoutEnd;
    }

    public async Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.LockoutEnd = lockoutEnd?.UtcDateTime;
        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
UPDATE public.user SET access_failed_count = access_failed_count + 1
WHERE user_id = @UserId 
RETURNING access_failed_count;";

        return await dataBaseManager.ExecuteScalarAsync<int>(query, new { user.UserId });
    }

    public async Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @"
UPDATE public.user SET access_failed_count = 0
WHERE user_id = @UserId;";

        await dataBaseManager.ExecuteAsync(query, new { user.UserId });
    }

    public async Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.AccessFailedCount;
    }

    public async Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.LockoutEnabled;
    }

    public async Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.LockoutEnabled = enabled;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task SetPhoneNumberAsync(User user, string? phoneNumber, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));
        
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.PhoneNumber = phoneNumber;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async  Task<string?> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.PhoneNumber;
    }

    public async Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.PhoneNumberConfirmed;
    }

    public async Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.PhoneNumberConfirmed = confirmed;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        dbUser.SecurityStamp = stamp;

        await UpdateAsync(dbUser, cancellationToken);
    }

    public async Task<string?> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
    {
        var dbUser = await FindByIdOrThrowAsync(user.UserId, cancellationToken);
        return dbUser.SecurityStamp;
    }

    public async Task AddLoginAsync(User user, UserLoginInfo loginInfo, CancellationToken cancellationToken)
    {
        var userLogin = new UserLogin
        {
            UserLoginId = Guid.NewGuid(),
            LoginProvider = loginInfo.LoginProvider,
            ProviderKey = loginInfo.ProviderKey,
            ProviderDisplayName = loginInfo.ProviderDisplayName,
            UserId = user.UserId,
            Status = Status.Active
        };
        const string insertQuery = @"
INSERT INTO public.user_login
    (user_login_id, login_provider, provider_key, provider_display_name, concurrency_stamp, status, created_at, modified_at, user_id) 
VALUES 
    (@UserLoginId, @LoginProvider, @ProviderKey, @ProviderDisplayName, @ConcurrencyStamp, @Status, @CreatedAt, @ModifiedAt, @UserId)";

        await dataBaseManager.ExecuteAsync(insertQuery, userLogin);
    }

    public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
        const string query = @"delete from public.user_login where provider_key = @ProviderKey and login_provider = @LoginProvider and user_id = @UserId";

        await dataBaseManager.ExecuteAsync(query, new { providerKey, loginProvider, user.UserId });
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
    {
        const string query = @$"
select
    user_login_id, login_provider, provider_key, provider_display_name, concurrency_stamp, status, created_at, modified_at, user_id
from public.user_login where user_id = @UserId;";
        
        cancellationToken.ThrowIfCancellationRequested();
        return (await dataBaseManager.QueryAsync<UserLogin>(query, new { user.UserId }))
            .Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.ProviderDisplayName)).ToList();
    }

    public async Task<User?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
        const string query = @$"
select
    {UserSelectString}
from public.user u
join public.user_login ul on u.user_id = ul.user_id
where ul.provider_key = @ProviderKey and ul.login_provider = @LoginProvider;
";
        
        cancellationToken.ThrowIfCancellationRequested();
        return await dataBaseManager.QuerySingleOrDefaultAsync<User>(query, new { loginProvider, providerKey });
    }
}