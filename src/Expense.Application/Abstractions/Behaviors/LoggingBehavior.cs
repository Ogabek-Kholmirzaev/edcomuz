using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expense.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            request);

        var timer = new Stopwatch();

        timer.Start();

        var response = await next();

        timer.Stop();

        var timerTaken = timer.Elapsed;

        logger.LogInformation(
            "[END] Handled {TRequest} with {TResponse}, Time: {Time} seconds",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            timerTaken.TotalSeconds);

        return response;
    }
}