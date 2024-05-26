using Lib.Services;
using Microsoft.AspNetCore.Http;

namespace Lib.Middleware;

public class TokenRefreshMiddleware(ITokenService tokenService, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var newToken = await tokenService.RefreshToken(token);
            context.Response.Headers.TryAdd("New-Token", newToken);
        }

        await next.Invoke(context);
    }
}