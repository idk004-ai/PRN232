using BusinessObjects.Exceptions;
using BusinessObjects.Models.DTOs;
using System.Text.Json;

namespace ProductWebAPI.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notfound)
        {
            await WriteJsonResponse(context, 404, notfound.Message);
        }
        catch (BadRequestException badRequest)
        {
            await WriteJsonResponse(context, 400, badRequest.Message);
        }
        catch (AuthenticationException auth)
        {
            await WriteJsonResponse(context, 401, auth.Message);
        }
        catch (InvalidOperationException invalid)
        {
            await WriteJsonResponse(context, 400, invalid.Message);
        }
        catch (ValidationException validation)
        {
            var errors = string.Join(", ", validation.Errors.SelectMany(e => e.Value));
            await WriteJsonResponse(context, 400, errors);
        }
        catch (ConflictException conflict)
        {
            await WriteJsonResponse(context, 409, conflict.Message);
        }
        catch (UnauthorizedAccessException unauthorized)
        {
            await WriteJsonResponse(context, 403, unauthorized.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await WriteJsonResponse(context, 500, "Something went wrong");
        }
    }

    private static async Task WriteJsonResponse(HttpContext context, int statusCode, string message)
    {
        if (context.Response.HasStarted)
        {
            return;
        }
        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        var response = new Response
        {
            Status = ResponseStatus.ERROR,
            Message = message
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var responseJson = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(responseJson);
    }
}