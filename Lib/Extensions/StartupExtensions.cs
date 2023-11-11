using Lib.DataAccess;
using Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection) =>
        serviceCollection.AddDataAccess();

    private static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDataBaseManager, DataBaseManager>()
            
            .AddScoped<IFileStorageDataAccess, LocalFileStorageDataAccess>()
            .AddScoped<LocalFileStorageDataAccess.IFileStreamWrapper, LocalFileStorageDataAccess.FileStreamWrapper>()
            
            .AddScoped<IEventDataAccess, EventDataAccess>()
            .AddScoped<MediaDataAccess, MediaDataAccess>()
            .AddScoped<IRoleDataAccess, RoleDataAccess>()
            .AddScoped<IUserDataAccess, UserDataAccess>();
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        // TODO: register all interfaces from IUserDataAccess

        serviceCollection
            .AddIdentity<User, Role>()
            .AddUserManager<IUserDataAccess>()
            .AddUserStore<IUserDataAccess>()
            .AddRoleManager<IUserDataAccess>()
            .AddRoleStore<IUserDataAccess>()
            .AddSignInManager<IUserDataAccess>()
            // .AddScoped<IUserStore<User>, UserDataAccess>()
            // .AddScoped<IRoleStore<Role>, RoleDataAccess>()
            .AddDefaultTokenProviders();
        return serviceCollection;
    }
}