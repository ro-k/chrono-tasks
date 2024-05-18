using System.Net;
using Microsoft.AspNetCore.Http;

namespace Lib.Exceptions;

public class ExceptionHandler(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (UserNotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (ConcurrencyStampMismatchException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.Conflict);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            error = exception.Message,
            statusCode = (int)statusCode
        };

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }    
}

