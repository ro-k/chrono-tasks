using System.Text;
using Lib.DataAccess;
using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
            .AddScoped<IParentDataAccess, ParentDataAccess>()
            .AddScoped<IUserContext, UserContext>();

        // allow dapper to properly map snake_case db fields to PascalCase model properties
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        return serviceCollection;
    }

    private static IServiceCollection AddServices(this IServiceCollection serviceCollection) => serviceCollection
        .AddScoped<IUserService, UserService>()
        .AddScoped<ISignInManagerWrapper, SignInManagerWrapper>()
        .AddScoped<IUserManagerWrapper, UserManagerWrapper>()
        .AddScoped<ICategoryService, CategoryService>()
        .AddScoped<ITreeViewService, TreeViewService>()
        .AddScoped<IJobService, JobService>()
        .AddScoped<IActivityService, ActivityService>()
        .AddScoped<IParentService, ParentService>()
        .AddScoped<ITokenService, TokenService>();

    private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        // identity-related stores
        services.AddScoped<IUserStore<User>, UserDataAccess>()
            .AddScoped<IUserRoleStore<User>, UserDataAccess>()
            .AddScoped<IUserEmailStore<User>, UserDataAccess>()
            .AddScoped<IUserLockoutStore<User>, UserDataAccess>()
            .AddScoped<IUserPhoneNumberStore<User>, UserDataAccess>()
            .AddScoped<IUserSecurityStampStore<User>, UserDataAccess>()
            .AddScoped<IUserLoginStore<User>, UserDataAccess>()
            // role store
            .AddScoped<IRoleStore<Role>, RoleDataAccess>()
            // framework-provided UserManager, RoleManager, and SignInManager
            .AddScoped<UserManager<User>>()
            .AddScoped<RoleManager<Role>>()
            .AddScoped<SignInManager<User>>()
            // setup Identity with custom user and role stores
            .AddIdentity<User, Role>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.User.RequireUniqueEmail = true;
            })
            .AddUserStore<UserDataAccess>()
            .AddRoleStore<RoleDataAccess>()
            .AddDefaultTokenProviders();

        return services;
    }



    public static IServiceCollection AddAuth(this IServiceCollection serviceCollection, AppSettings appSettings)
    {
        serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidAudience = appSettings.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtKey!)),
                };
            });

        return serviceCollection;
    }
}