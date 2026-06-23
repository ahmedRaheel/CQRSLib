namespace FastCqrs;

/// <summary>
/// Non-generic marker implemented by every request-like message (commands, queries, stream queries).
/// Never implement this directly — use <see cref="IRequest{TResponse}"/>, <see cref="ICommand{TResponse}"/>,
/// <see cref="IQuery{TResponse}"/> or <see cref="IStreamQuery{TResponse}"/> instead.
/// </summary>
public interface IBaseRequest
{
}

/// <summary>
/// A request that is dispatched to exactly one handler and produces a single <typeparamref name="TResponse"/>.
/// This is the common base for both <see cref="ICommand{TResponse}"/> and <see cref="IQuery{TResponse}"/>.
/// Prefer the CQRS-flavored markers in application code; implement this directly only for requests that are
/// genuinely neither a command nor a query.
/// </summary>
/// <typeparam name="TResponse">The type returned by the handler.</typeparam>
public interface IRequest<out TResponse> : IBaseRequest
{
}

/// <summary>
/// A request that mutates state and returns a value (e.g. the id of a newly created entity).
/// </summary>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

/// <summary>
/// A request that mutates state and does not return a meaningful value.
/// </summary>
public interface ICommand : IRequest<Unit>
{
}

/// <summary>
/// A request that reads state without causing side effects.
/// </summary>
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

/// <summary>
/// A query whose result is streamed incrementally rather than materialized all at once.
/// Dispatched via <see cref="ISender.CreateStream{TResponse}"/>.
/// </summary>
public interface IStreamQuery<out TResponse> : IBaseRequest
{
}
