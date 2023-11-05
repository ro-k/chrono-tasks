using Lib.Models;
using Microsoft.AspNetCore.Identity;

namespace Lib.DataAccess;

public interface IRoleDataAccess : IRoleStore<Role>
{
}