namespace FastCqrs.Decorators;

/// <summary>
/// Base class for cross-cutting concerns (logging, validation, caching, retries, transactions...) that
/// wrap a request handler. Unlike MediatR's <c>IPipelineBehavior&lt;TRequest,TResponse&gt;</c>, decorators
/// are not resolved as an <c>IEnumerable&lt;&gt;</c> and chained together on every single dispatch -
/// the chain is built once, when the container is built, via <see cref="FastCqrs.DependencyInjection.ServiceCollectionDecorationExtensions.Decorate{TService,TDecorator}"/>.
/// Each decorator is just another implementation of <see cref="IRequestHandler{TRequest,TResponse}"/>
/// that happens to hold the real handler (or the next decorator) as a constructor dependency, so a
/// request flowing through N decorators is N ordinary virtual calls, not a runtime-assembled pipeline.
/// </summary>
/// <remarks>
/// Because decorators are themselves generic and resolved by their generic constraints, you can scope a
/// decorator to commands only, queries only, or a specific request, simply by constraining
/// <typeparamref name="TRequest"/> - registrations that don't satisfy the constraint are silently left
/// undecorated. See the Caching/Retry sample decorators for examples.
/// </remarks>
public abstract class RequestHandlerDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected RequestHandlerDecorator(IRequestHandler<TRequest, TResponse> inner)
    {
        Inner = inner;
    }

    /// <summary>The wrapped handler - either the real handler, or the next decorator in the chain.</summary>
    protected IRequestHandler<TRequest, TResponse> Inner { get; }

    public abstract ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

/// <summary>The notification equivalent of <see cref="RequestHandlerDecorator{TRequest,TResponse}"/>.</summary>
public abstract class NotificationHandlerDecorator<TNotification> : INotificationHandler<TNotification>
    where TNotification : INotification
{
    protected NotificationHandlerDecorator(INotificationHandler<TNotification> inner)
    {
        Inner = inner;
    }

    protected INotificationHandler<TNotification> Inner { get; }

    public abstract ValueTask Handle(TNotification notification, CancellationToken cancellationToken);
}
