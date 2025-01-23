using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CSharpApp.Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Started request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        Stopwatch stopwatch = new();

        stopwatch.Start();

        var result = await next();

        stopwatch.Stop();

        if (result.IsFailure)
        {
            _logger.LogError("Request failure {@RequestName}, {@DateTimeUtc}\nReason: {@Reason}",
                typeof(TRequest).Name,
                DateTime.UtcNow,
                result.Error);
        }

        _logger.LogInformation("Completed request {@RequestName}, {@DateTimeUtc}\nTimeElapsed(ms): {@TimeElapsed}ms",
            typeof(TRequest).Name,
            DateTime.UtcNow,
            stopwatch.ElapsedMilliseconds);

        return result;
    }
}
