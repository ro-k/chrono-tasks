using System.Security.Claims;
using Lib.Services;
using Microsoft.AspNetCore.Http;

namespace Lib.Middleware;

public class UserContextMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IUserContext userContext)
    {
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out var userId))
            {
                userContext.UserId = userId;
            }
        }

        await next(context);
    }
}