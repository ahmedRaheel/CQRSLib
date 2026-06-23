using System.Reflection;
using FastCqrs.Dispatch;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FastCqrs.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private static readonly Type[] OpenHandlerInterfaces =
    {
        typeof(IRequestHandler<,>),
        typeof(ICommandHandler<,>),
        typeof(ICommandHandler<>),   // void-returning commands; inherits IRequestHandler<TCommand,Unit>
        typeof(IQueryHandler<,>),
        typeof(INotificationHandler<>),
        typeof(IStreamQueryHandler<,>),
    };

    /// <summary>
    /// Registers <see cref="IDispatcher"/>/<see cref="ISender"/>/<see cref="IPublisher"/> and the default
    /// notification publish strategy, without scanning any assembly for handlers. Use this together with
    /// the source-generated <c>AddGeneratedFastCqrsHandlers()</c> extension method (from the
    /// FastCqrs.Generators package) when you want handler registration to happen at compile time instead
    /// of via reflection.
    /// </summary>
    public static IServiceCollection AddFastCqrs(this IServiceCollection services)
        => services.AddFastCqrs(static _ => { });

    /// <summary>
    /// Registers <see cref="IDispatcher"/>/<see cref="ISender"/>/<see cref="IPublisher"/> and, for every
    /// assembly passed to <see cref="FastCqrsOptions.RegisterServicesFromAssembly"/>, scans it for handler
    /// implementations and registers each one under the handler interface(s) it implements.
    /// </summary>
    public static IServiceCollection AddFastCqrs(this IServiceCollection services, Action<FastCqrsOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new FastCqrsOptions();
        configure(options);

        services.TryAddSingleton(typeof(INotificationPublishStrategy), options.NotificationPublishStrategyType);

        services.TryAddTransient<IDispatcher, Dispatcher>();
        services.TryAddTransient<ISender>(sp => sp.GetRequiredService<IDispatcher>());
        services.TryAddTransient<IPublisher>(sp => sp.GetRequiredService<IDispatcher>());

        foreach (var assembly in options.AssembliesToScan)
        {
            RegisterHandlersFromAssembly(services, assembly, options.HandlerLifetime);
        }

        return services;
    }

    /// <summary>
    /// Reflection-based handler discovery, run once at startup. If you need to avoid assembly scanning
    /// entirely (e.g. for trimming/Native AOT), reference the FastCqrs.Generators package instead, call
    /// the parameterless <see cref="AddFastCqrs(IServiceCollection)"/> overload for the core dispatcher
    /// registrations, and call the generated <c>AddGeneratedFastCqrsHandlers()</c> extension method for
    /// handlers - the two registration paths are alternatives, not additive: registering the same handler
    /// both ways would cause notification handlers to run twice.
    /// </summary>
    private static void RegisterHandlersFromAssembly(IServiceCollection services, Assembly assembly, ServiceLifetime lifetime)
    {
        foreach (var type in GetLoadableTypes(assembly))
        {
            if (!type.IsClass || type.IsAbstract)
            {
                continue;
            }

            foreach (var implementedInterface in type.GetInterfaces())
            {
                if (!implementedInterface.IsGenericType)
                {
                    continue;
                }

                var openInterface = implementedInterface.GetGenericTypeDefinition();
                if (Array.IndexOf(OpenHandlerInterfaces, openInterface) < 0)
                {
                    continue;
                }

                services.Add(new ServiceDescriptor(implementedInterface, type, lifetime));
            }
        }
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(t => t is not null)!;
        }
    }
}
