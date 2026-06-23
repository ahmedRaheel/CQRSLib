using System.Reflection;
using FastCqrs.Dispatch;
using Microsoft.Extensions.DependencyInjection;

namespace FastCqrs.DependencyInjection;

public sealed class FastCqrsOptions
{
    internal List<Assembly> AssembliesToScan { get; } = new();

    internal ServiceLifetime HandlerLifetime { get; private set; } = ServiceLifetime.Transient;

    internal Type NotificationPublishStrategyType { get; private set; } = typeof(ParallelPublishStrategy);

    /// <summary>Scans <paramref name="assembly"/> for handler implementations and registers them.</summary>
    public FastCqrsOptions RegisterServicesFromAssembly(Assembly assembly)
    {
        AssembliesToScan.Add(assembly);
        return this;
    }

    /// <summary>Convenience overload of <see cref="RegisterServicesFromAssembly"/> using a marker type's assembly.</summary>
    public FastCqrsOptions RegisterServicesFromAssemblyContaining<TMarker>()
        => RegisterServicesFromAssembly(typeof(TMarker).Assembly);

    /// <summary>Controls the DI lifetime handlers are registered with. Defaults to <see cref="ServiceLifetime.Transient"/>.</summary>
    public FastCqrsOptions UseHandlerLifetime(ServiceLifetime lifetime)
    {
        HandlerLifetime = lifetime;
        return this;
    }

    /// <summary>
    /// Controls how a notification's handlers are invoked relative to one another.
    /// Defaults to <see cref="ParallelPublishStrategy"/>.
    /// </summary>
    public FastCqrsOptions UseNotificationPublishStrategy<TStrategy>()
        where TStrategy : class, INotificationPublishStrategy
    {
        NotificationPublishStrategyType = typeof(TStrategy);
        return this;
    }
}
