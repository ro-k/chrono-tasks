using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Npgsql;

namespace Lib.DataAccess;

public class UserDataAccess : IUserDataAccess
{
    private readonly IDataBaseManager _dataBaseManager;

    public UserDataAccess(IDataBaseManager dataBaseManager)
    {
        _dataBaseManager = dataBaseManager;
    }

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
    
        const string selectQuery = @"
SELECT 
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
FROM public.user 
WHERE 
    user_id = @UserId";
        
        ct.ThrowIfCancellationRequested();
    
        return await _dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery, new { UserId = userId });
    }


    public async Task<User> FindByNameAsync(string userName, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return null!;
        }
    
        const string selectQuery = @"
SELECT 
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
FROM public.user 
WHERE 
    normalized_user_name = @NormalizedUserName";
    
        ct.ThrowIfCancellationRequested();
        
        return await _dataBaseManager.QuerySingleOrDefaultAsync<User>(selectQuery, new { NormalizedUserName = userName.Normalize() });
    }
    
    public async Task<string> GetUserIdAsync(User user, CancellationToken ct)
    {
        return (await FindByNameAsync(user.UserName, ct)).UserId.ToString();
    }

    public async Task<string> GetUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdAsync(user.UserId.ToString(), ct)).UserName;
    }

    public async Task SetUserNameAsync(User user, string userName, CancellationToken ct)
    {
        var dbUser = await FindByIdAsync(user.UserId.ToString(), ct);
        dbUser.UserName = userName;
        await UpdateAsync(dbUser, ct);
    }

    public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken ct)
    {
        return (await FindByIdAsync(user.UserId.ToString(), ct)).NormalizedUserName;
    }

    public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken ct)
    {
        var dbUser = await FindByIdAsync(user.UserId.ToString(), ct);
        dbUser.NormalizedUserName = normalizedName;
        await UpdateAsync(dbUser, ct);
    }

    public void Dispose()
    {
    }
}