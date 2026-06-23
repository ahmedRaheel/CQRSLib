using FastCqrs;
using FastCqrs.Decorators;
using System.Diagnostics;

namespace LibraryService.Api.Domain.Abstraction.Decoders;

public sealed class LoggingDecorator<TRequest, TResponse> : RequestHandlerDecorator<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;
    public LoggingDecorator(ILogger<LoggingDecorator<TRequest, TResponse>> logger, IRequestHandler<TRequest, TResponse> inner) : base(inner)
    {
        _logger = logger;
    }

    public override async ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[log] -> {typeof(TRequest).Name}");
        var stopwatch = Stopwatch.StartNew();
        try
        {
            var response = await Inner.Handle(request, cancellationToken);           
            stopwatch.Stop();
            return response;
        }
        catch (Exception ex)
        { 
          _logger.LogError($"[log] x  {typeof(TRequest).Name} failed: {ex.Message}",ex);
            throw;
        }
    }
}
