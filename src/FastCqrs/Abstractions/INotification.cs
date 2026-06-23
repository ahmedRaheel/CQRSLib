namespace FastCqrs;

/// <summary>
/// A fire-and-forget event that zero, one, or many handlers may react to. Unlike requests, notifications
/// are not expected to return a value and a missing handler is not an error.
/// </summary>
public interface INotification
{
}

/// <summary>Reacts to a published <typeparamref name="TNotification"/>.</summary>
public interface INotificationHandler<in TNotification>
    where TNotification : INotification
{
    ValueTask Handle(TNotification notification, CancellationToken cancellationToken);
}
