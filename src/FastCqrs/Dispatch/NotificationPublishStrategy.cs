namespace FastCqrs.Dispatch;

/// <summary>
/// Controls how a notification's handlers are invoked relative to each other. Register a custom
/// implementation in DI to change the default for the whole application (see
/// <see cref="FastCqrs.DependencyInjection.FastCqrsOptions.NotificationPublishStrategy"/>).
/// </summary>
public interface INotificationPublishStrategy
{
    ValueTask Publish<TNotification>(
        IEnumerable<INotificationHandler<TNotification>> handlers,
        TNotification notification,
        CancellationToken cancellationToken)
        where TNotification : INotification;
}

/// <summary>Awaits each handler one after another, in registration order. Stops at the first exception.</summary>
public sealed class SequentialPublishStrategy : INotificationPublishStrategy
{
    public async ValueTask Publish<TNotification>(
        IEnumerable<INotificationHandler<TNotification>> handlers,
        TNotification notification,
        CancellationToken cancellationToken)
        where TNotification : INotification
    {
        foreach (var handler in handlers)
        {
            await handler.Handle(notification, cancellationToken).ConfigureAwait(false);
        }
    }
}

/// <summary>
/// Runs all handlers concurrently and waits for every one to finish. If multiple handlers throw,
/// exceptions are preserved on the returned task; awaiting rethrows according to normal Task.WhenAll semantics.
/// </summary>
public sealed class ParallelPublishStrategy : INotificationPublishStrategy
{
    public async ValueTask Publish<TNotification>(
        IEnumerable<INotificationHandler<TNotification>> handlers,
        TNotification notification,
        CancellationToken cancellationToken)
        where TNotification : INotification
    {
        var tasks = handlers
            .Select(handler => handler.Handle(notification, cancellationToken).AsTask())
            .ToArray();

        if (tasks.Length == 0)
        {
            return;
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}
