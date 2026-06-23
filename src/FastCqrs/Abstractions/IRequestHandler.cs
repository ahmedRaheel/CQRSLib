namespace FastCqrs;

/// <summary>
/// Handles a single <typeparamref name="TRequest"/> and produces a <typeparamref name="TResponse"/>.
/// This is the contract the dispatcher resolves from the container — command and query handlers
/// also satisfy this interface, so a handler is always reachable through it regardless of which
/// CQRS-flavored handler interface it was declared with.
/// </summary>
public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

/// <summary>Handles a command that returns <typeparamref name="TResponse"/>.</summary>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}

/// <summary>Handles a command that returns no meaningful value.</summary>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand
{
}

/// <summary>Handles a query and returns <typeparamref name="TResponse"/>.</summary>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}

/// <summary>Handles a streaming query, yielding results as they become available.</summary>
public interface IStreamQueryHandler<in TQuery, out TResponse>
    where TQuery : IStreamQuery<TResponse>
{
    IAsyncEnumerable<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
