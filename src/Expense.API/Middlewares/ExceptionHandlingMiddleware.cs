using Expense.Application.Exceptions;
using Expense.Infrastructure.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{   
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurence {time}",
                exception.Message,
                DateTime.UtcNow);
            
            (string Detail, string Title, int StatusCode) details = exception switch
            {
                InternalServerException =>
                    (exception.Message, exception.GetType().Name, StatusCodes.Status500InternalServerError),
                ValidationException or BadRequestException =>
                    (exception.Message, exception.GetType().Name, StatusCodes.Status400BadRequest),
                NotFoundException =>
                    (exception.Message, exception.GetType().Name, StatusCodes.Status404NotFound),
                _ =>
                    (exception.Message, exception.GetType().Name, StatusCodes.Status500InternalServerError),
            };

            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

            if (exception is ValidationException validationException)
            {
                problemDetails.Extensions.Add(
                    "ValidationErrors",
                    validationException.Errors.Select(failure =>
                        new
                        {
                            PropertyName = failure.PropertyName,
                            ErrorMessage = failure.ErrorMessage
                        }));
            }

            httpContext.Response.StatusCode = details.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}