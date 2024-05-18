using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.DataAccess;

public interface IRoleDataAccess : IRoleStore<Role>
{
    Task<Role> FindByNameOrThrowAsync(string roleName, CancellationToken ct);
}