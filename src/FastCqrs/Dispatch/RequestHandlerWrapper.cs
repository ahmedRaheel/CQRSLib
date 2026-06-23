using FastCqrs.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace FastCqrs.Dispatch;

/// <summary>
/// Resolves and invokes the handler for a request whose concrete type is only known at runtime
/// (the dispatcher only sees <c>IRequest&lt;TResponse&gt;</c>). One closed instance of
/// <see cref="RequestHandlerWrapperImpl{TRequest,TResponse}"/> is created per request type via
/// <see cref="Activator.CreateInstance(Type)"/> and cached for the lifetime of the process, so the
/// reflection cost is paid once per request *type*, never once per request *instance*.
/// </summary>
internal abstract class RequestHandlerWrapper<TResponse>
{
    public abstract ValueTask<TResponse> Handle(IRequest<TResponse> request, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}

internal sealed class RequestHandlerWrapperImpl<TRequest, TResponse> : RequestHandlerWrapper<TResponse>
    where TRequest : IRequest<TResponse>
{
    public override ValueTask<TResponse> Handle(IRequest<TResponse> request, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var handler = serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>()
            ?? throw new HandlerNotFoundException(typeof(TRequest));
        return handler.Handle((TRequest)request, cancellationToken);
    }
}

/// <summary>Same idea as <see cref="RequestHandlerWrapper{TResponse}"/>, for streaming queries.</summary>
internal abstract class StreamRequestHandlerWrapper<TResponse>
{
    public abstract IAsyncEnumerable<TResponse> Handle(IStreamQuery<TResponse> query, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}

internal sealed class StreamRequestHandlerWrapperImpl<TQuery, TResponse> : StreamRequestHandlerWrapper<TResponse>
    where TQuery : IStreamQuery<TResponse>
{
    public override IAsyncEnumerable<TResponse> Handle(IStreamQuery<TResponse> query, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var handler = serviceProvider.GetService<IStreamQueryHandler<TQuery, TResponse>>()
            ?? throw new HandlerNotFoundException(typeof(TQuery));
        return handler.Handle((TQuery)query, cancellationToken);
    }
}
