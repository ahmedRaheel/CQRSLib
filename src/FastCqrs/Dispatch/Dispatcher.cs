using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace FastCqrs.Dispatch;

internal sealed class Dispatcher : IDispatcher
{
    // Shared across every Dispatcher instance (it's registered as transient/scoped so it can be
    // resolved cheaply per-request in web apps) because the wrappers themselves are stateless -
    // they only close over a request Type, never over an IServiceProvider instance.
    private static readonly ConcurrentDictionary<Type, object> RequestWrappers = new();
    private static readonly ConcurrentDictionary<Type, object> StreamWrappers = new();

    private readonly IServiceProvider _serviceProvider;
    private readonly INotificationPublishStrategy _publishStrategy;

    public Dispatcher(IServiceProvider serviceProvider, INotificationPublishStrategy publishStrategy)
    {
        _serviceProvider = serviceProvider;
        _publishStrategy = publishStrategy;
    }

    public ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        var requestType = request.GetType();
        var wrapper = (RequestHandlerWrapper<TResponse>)RequestWrappers.GetOrAdd(requestType, rt => CreateRequestWrapper(rt, typeof(TResponse)));

        return wrapper.Handle(request, _serviceProvider, cancellationToken);
    }

    public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(
        IStreamQuery<TResponse> query,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryType = query.GetType();
        var wrapper = (StreamRequestHandlerWrapper<TResponse>)StreamWrappers.GetOrAdd(queryType, qt => CreateStreamWrapper(qt, typeof(TResponse)));

        await foreach (var item in wrapper.Handle(query, _serviceProvider, cancellationToken).WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            yield return item;
        }
    }

    public ValueTask Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        ArgumentNullException.ThrowIfNull(notification);

        var handlers = _serviceProvider.GetServices<INotificationHandler<TNotification>>();
        return _publishStrategy.Publish(handlers, notification, cancellationToken);
    }

    private static object CreateRequestWrapper(Type requestType, Type responseType)
    {
        var wrapperType = typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, responseType);
        return Activator.CreateInstance(wrapperType)
            ?? throw new InvalidOperationException($"Could not create a dispatch wrapper for request type '{requestType}'.");
    }

    private static object CreateStreamWrapper(Type queryType, Type responseType)
    {
        var wrapperType = typeof(StreamRequestHandlerWrapperImpl<,>).MakeGenericType(queryType, responseType);
        return Activator.CreateInstance(wrapperType)
            ?? throw new InvalidOperationException($"Could not create a dispatch wrapper for stream query type '{queryType}'.");
    }
}
