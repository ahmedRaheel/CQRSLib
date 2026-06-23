using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Api.Infrastructure.External.Authentication;
public static class AuthenticationExtensions
{
    public static IServiceCollection AddExternalAuthentication(this IServiceCollection services, IConfiguration configuration) => services;
}