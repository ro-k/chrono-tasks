using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection) =>
        serviceCollection.AddDataAccess().AddServices().ConfigureIdentity();

    private static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDataBaseManager, DataBaseManager>()

            .AddScoped<IFileStorageDataAccess, LocalFileStorageDataAccess>()
            .AddScoped<LocalFileStorageDataAccess.IFileStreamWrapper, LocalFileStorageDataAccess.FileStreamWrapper>()

            .AddScoped<IActivityDataAccess, ActivityDataAccess>()
            .AddScoped<ICategoryDataAccess, CategoryDataAccess>()
            .AddScoped<IMediaDataAccess, MediaDataAccess>()
            .AddScoped<IRoleDataAccess, RoleDataAccess>()
            .AddScoped<IJobDataAccess, JobDataAccess>()
            .AddScoped<IUserDataAccess, UserDataAccess>()
            .AddScoped<ITreeViewDataAccess, TreeViewDataAccess>()
            .AddScoped<IUserContext, UserContext>();

        // allow dapper to properly map snake_case db fields to PascalCase model properties
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        return serviceCollection;
    }

    private static IServiceCollection AddServices(this IServiceCollection serviceCollection) => serviceCollection
        .AddScoped<IAuthService, AuthService>()
        .AddScoped<ISignInManagerWrapper, SignInManagerWrapper>()
        .AddScoped<ICategoryService, CategoryService>()
        .AddScoped<ITreeViewService, TreeViewService>()
        .AddScoped<IJobService, JobService>();

    private static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        // TODO: register all interfaces from IUserDataAccess
        serviceCollection
            //.AddScoped<IUserStore<User>, UserDataAccess>()
            .AddScoped<IUserRoleStore<User>, UserDataAccess>()
            .AddScoped<IUserEmailStore<User>, UserDataAccess>()
            .AddScoped<IUserLockoutStore<User>, UserDataAccess>()
            .AddScoped<IUserPhoneNumberStore<User>, UserDataAccess>()
            .AddScoped<IUserSecurityStampStore<User>, UserDataAccess>()
            .AddScoped<IUserLoginStore<User>, UserDataAccess>()
            .AddScoped<IUserStore<User>, UserDataAccess>()
            .AddScoped<IRoleStore<Role>, RoleDataAccess>();
            //.AddScoped<IRoleStore<Role>, RoleDataAccess>();
        
        serviceCollection
            .AddIdentity<User, Role>()
            .AddUserStore<UserDataAccess>()
            .AddRoleStore<RoleDataAccess>()
            .AddDefaultTokenProviders();
        
            // .AddUserManager<IUserDataAccess>()
            // .AddRoleManager<IUserDataAccess>()
            // .AddSignInManager<IUserDataAccess>()
            
            
        return serviceCollection;
    }
}