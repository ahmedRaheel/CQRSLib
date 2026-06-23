namespace FastCqrs.Exceptions;

/// <summary>
/// Thrown when a request, query or stream query has no registered handler. Notifications never throw
/// this - publishing to zero handlers is a no-op by design.
/// </summary>
public sealed class HandlerNotFoundException : Exception
{
    public HandlerNotFoundException(Type requestType)
        : base($"No handler was registered for request type '{requestType.FullName}'. " +
               "Make sure the assembly containing the handler was passed to AddFastCqrs(...), " +
               "or that AddGeneratedFastCqrsHandlers() was called if you're using the source generator.")
    {
        RequestType = requestType;
    }

    public Type RequestType { get; }
}
