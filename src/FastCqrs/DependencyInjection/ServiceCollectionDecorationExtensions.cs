using Microsoft.Extensions.DependencyInjection;

namespace FastCqrs.DependencyInjection;

/// <summary>
/// Wraps already-registered services with a decorator, in place, at the container-build step - the same
/// technique used by Scrutor's <c>Decorate()</c>, implemented here directly so FastCqrs has no third-party
/// dependency. This is what lets FastCqrs use the plain GoF Decorator pattern for cross-cutting concerns
/// instead of MediatR's separately-resolved, dynamically-chained pipeline behaviors: the decoration happens
/// once, here, rather than being re-assembled out of an <c>IEnumerable&lt;&gt;</c> on every dispatch.
/// </summary>
public static class ServiceCollectionDecorationExtensions
{
    /// <summary>Wraps every registration of the closed generic service <typeparamref name="TService"/>.</summary>
    public static IServiceCollection Decorate<TService, TDecorator>(this IServiceCollection services)
        where TDecorator : class, TService
        where TService : class
        => services.Decorate(typeof(TService), typeof(TDecorator));

    /// <summary>
    /// Wraps every registration matching <paramref name="serviceType"/>, which may be an open generic
    /// type definition (e.g. <c>typeof(IRequestHandler&lt;,&gt;)</c>) to decorate every handler at once.
    /// If <paramref name="decoratorType"/> is itself an open generic type whose constraints don't match a
    /// particular registration's type arguments (for example a decorator constrained to
    /// <c>where TRequest : ICommand&lt;TResponse&gt;</c> encountering a query handler), that registration
    /// is silently left undecorated - this is what makes command-only / query-only decorators possible
    /// without any manual type-checking inside the decorator's <c>Handle</c> method.
    /// </summary>
    public static IServiceCollection Decorate(this IServiceCollection services, Type serviceType, Type decoratorType)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(serviceType);
        ArgumentNullException.ThrowIfNull(decoratorType);

        var matches = services
            .Select((descriptor, index) => (descriptor, index))
            .Where(x => IsMatch(x.descriptor.ServiceType, serviceType))
            .ToList();

        if (matches.Count == 0)
        {
            throw new InvalidOperationException(
                $"Cannot decorate '{serviceType}' because no services have been registered for it yet. " +
                "Call Decorate(...) after registering the services it wraps (e.g. after AddFastCqrs).");
        }

        foreach (var (originalDescriptor, index) in matches)
        {
            Type concreteDecoratorType;

            if (decoratorType.IsGenericTypeDefinition)
            {
                try
                {
                    concreteDecoratorType = decoratorType.MakeGenericType(originalDescriptor.ServiceType.GetGenericArguments());
                }
                catch (ArgumentException)
                {
                    // The decorator's generic constraints don't accept this particular registration's type
                    // arguments - leave it undecorated rather than failing the whole registration.
                    continue;
                }
            }
            else
            {
                concreteDecoratorType = decoratorType;
            }

            var decoratedServiceType = originalDescriptor.ServiceType;
            var capturedInner = originalDescriptor;

            services[index] = new ServiceDescriptor(
                decoratedServiceType,
                provider => CreateDecorator(provider, capturedInner, concreteDecoratorType),
                originalDescriptor.Lifetime);
        }

        return services;
    }

    private static bool IsMatch(Type registeredServiceType, Type targetServiceType)
    {
        if (registeredServiceType == targetServiceType)
        {
            return true;
        }

        return targetServiceType.IsGenericTypeDefinition
            && registeredServiceType.IsGenericType
            && registeredServiceType.GetGenericTypeDefinition() == targetServiceType;
    }

    private static object CreateDecorator(IServiceProvider provider, ServiceDescriptor innerDescriptor, Type decoratorType)
    {
        var inner = ResolveInner(provider, innerDescriptor);
        return ActivatorUtilities.CreateInstance(provider, decoratorType, inner);
    }

    private static object ResolveInner(IServiceProvider provider, ServiceDescriptor innerDescriptor)
    {
        if (innerDescriptor.ImplementationInstance is { } instance)
        {
            return instance;
        }

        if (innerDescriptor.ImplementationFactory is { } factory)
        {
            return factory(provider);
        }

        if (innerDescriptor.ImplementationType is { } implementationType)
        {
            return ActivatorUtilities.CreateInstance(provider, implementationType);
        }

        throw new InvalidOperationException($"Service descriptor for '{innerDescriptor.ServiceType}' has no implementation to decorate.");
    }
}
