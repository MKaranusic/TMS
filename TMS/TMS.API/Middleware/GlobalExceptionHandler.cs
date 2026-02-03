using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TMS.API.Utilities;

namespace TMS.API.Middleware;

public class EnhancedGlobalExceptionHandler(ILogger<EnhancedGlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var traceId = httpContext.TraceIdentifier;

        var (statusCode, title, logLevel) = exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, Messages.GlobalErrorHandler.ValidationFailed, LogLevel.Warning),
            ArgumentException => (StatusCodes.Status400BadRequest, Messages.GlobalErrorHandler.InvalidRequest, LogLevel.Warning),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, Messages.GlobalErrorHandler.Unauthorized, LogLevel.Warning),
            KeyNotFoundException => (StatusCodes.Status404NotFound, Messages.GlobalErrorHandler.NotFound, LogLevel.Information),
            InvalidOperationException => (StatusCodes.Status409Conflict, Messages.GlobalErrorHandler.OperationNotAllowed, LogLevel.Warning),
            TimeoutException => (StatusCodes.Status408RequestTimeout, Messages.GlobalErrorHandler.Timeout, LogLevel.Warning),
            NotSupportedException => (StatusCodes.Status400BadRequest, Messages.GlobalErrorHandler.UnsupportedAction, LogLevel.Warning),
            DbUpdateException => (StatusCodes.Status500InternalServerError, Messages.GlobalErrorHandler.Database, LogLevel.Error),
            _ => (StatusCodes.Status500InternalServerError, Messages.GlobalErrorHandler.General, LogLevel.Error)
        };

        // Log with appropriate level
        logger.Log(logLevel, exception,
            "Exception occurred. Type: {ExceptionType}, TraceId: {TraceId}, Path: {Path}, Method: {Method}, StatusCode: {StatusCode}",
            exception.GetType().Name, traceId, httpContext.Request.Path, httpContext.Request.Method, statusCode);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = GetProblemTypeUri(statusCode),
            Instance = httpContext.Request.Path,
        };

        if (ShouldIncludeDetails(httpContext, exception))
        {
            problemDetails.Detail = exception.Message;
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }

    private static bool ShouldIncludeDetails(HttpContext context, Exception exception)
    {
        var env = context.RequestServices.GetService<IWebHostEnvironment>();
        return env?.IsDevelopment() == true ||
               exception is ValidationException or ArgumentException or InvalidOperationException;
    }

    private static string GetProblemTypeUri(int statusCode) => statusCode switch
    {
        400 => "https://tools.ietf.org/html/rfc9110#section-15.5.1",
        401 => "https://tools.ietf.org/html/rfc9110#section-15.5.2",
        404 => "https://tools.ietf.org/html/rfc9110#section-15.5.5",
        409 => "https://tools.ietf.org/html/rfc9110#section-15.5.10",
        _ => "https://tools.ietf.org/html/rfc9110#section-15.6.1"
    };
}