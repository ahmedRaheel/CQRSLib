namespace FastCqrs;

/// <summary>Dispatches commands and queries to their single handler.</summary>
public interface ISender
{
    /// <summary>Sends a command or query and awaits its response.</summary>
    ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

    /// <summary>Opens a streaming query and yields results as they arrive.</summary>
    IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamQuery<TResponse> query, CancellationToken cancellationToken = default);
}

/// <summary>Publishes notifications to zero or more subscribers.</summary>
public interface IPublisher
{
    ValueTask Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification;
}

/// <summary>Combined entry point exposing both sending and publishing. This is the type most applications inject.</summary>
public interface IDispatcher : ISender, IPublisher
{
}
