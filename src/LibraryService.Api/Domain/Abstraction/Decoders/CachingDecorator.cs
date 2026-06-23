using FastCqrs;
using FastCqrs.Decorators;
using System.Collections.Concurrent;
using System.Text.Json;

namespace LibraryService.Api.Domain.Abstraction.Decoders;

public sealed class CachingDecorator<TQuery, TResponse> : RequestHandlerDecorator<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    private static readonly ConcurrentDictionary<string, (TResponse Value, DateTimeOffset ExpiresAt)> Cache = new();
    private static readonly TimeSpan Ttl = TimeSpan.FromSeconds(30);

    public CachingDecorator(IRequestHandler<TQuery, TResponse> inner) : base(inner)
    {
    }

    public override async ValueTask<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var key = $"{typeof(TQuery).FullName}:{JsonSerializer.Serialize(request)}";

        if (Cache.TryGetValue(key, out var cached) && cached.ExpiresAt > DateTimeOffset.UtcNow)
        {
            Console.WriteLine($"[cache] hit  {typeof(TQuery).Name}");
            return cached.Value;
        }

        Console.WriteLine($"[cache] miss {typeof(TQuery).Name}");
        var response = await Inner.Handle(request, cancellationToken);
        Cache[key] = (response, DateTimeOffset.UtcNow.Add(Ttl));
        return response;
    }
}
