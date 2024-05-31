using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Middleware;

public class TokenRefreshMiddleware(IServiceScopeFactory serviceScopeFactory, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var (needRefresh, newToken) = await tokenService.TryRefreshToken(token);
            if (needRefresh) context.Response.Headers.TryAdd("new-token", newToken);
        }

        await next.Invoke(context);
    }
}