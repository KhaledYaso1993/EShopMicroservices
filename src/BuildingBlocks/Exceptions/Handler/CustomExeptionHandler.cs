

using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler;

public class CustomExeptionHandler
    (ILogger<CustomExeptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("Error Message:{exceptionMessage} time of occourence {time} ", exception.Message, DateTime.UtcNow);


        (string Detail, string Title, int StatusCode) details = exception switch
        {

            NotFoundException => (
            exception.Message,
            exception.GetType().Name,
            context.Response.StatusCode = StatusCodes.Status404NotFound
            ),

            InternalServerException => (
            exception.Message,
            exception.GetType().Name,
            context.Response.StatusCode = StatusCodes.Status500InternalServerError
            ),

            ValidationException =>
            (
            exception.Message,
            exception.GetType().Name,
            context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            BadRequestException => (
            exception.Message,
            exception.GetType().Name,
            context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            _ => (
            exception.Message,
            exception.GetType().Name,
            context.Response.StatusCode = StatusCodes.Status500InternalServerError
            )

        };

        var problemDetailes = new ProblemDetails()
        {

            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = context.Request.Path
        };

        problemDetailes.Extensions.Add("TraceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetailes.Extensions.Add("ValidationError", validationException.Errors);
        }

        await context.Response.WriteAsJsonAsync(problemDetailes, cancellationToken: cancellationToken);

        return true;
    }
}
