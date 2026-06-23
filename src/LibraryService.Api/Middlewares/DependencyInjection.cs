using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Infrastructure.Data.Commands;
using LibraryService.Api.Infrastructure.Data.Persistence.Context;
using LibraryService.Api.Infrastructure.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace LibraryService.Api.Middlewares;
public static class DependencyInjection
{
    public static IServiceCollection AddApiInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IApplicationDbConnectionFactory>(_ => new ApplicationDbConnectionFactory(connectionString ?? string.Empty));
        services.AddScoped<IAuthorCommandRepository, AuthorCommandRepository>();
        services.AddScoped<IAuthorQueryRepository, AuthorQueryRepository>();
        services.AddScoped<IBookCommandRepository, BookCommandRepository>();
        services.AddScoped<IBookQueryRepository, BookQueryRepository>();
        services.AddScoped<IBookAuthorCommandRepository, BookAuthorCommandRepository>();
        services.AddScoped<IBookAuthorQueryRepository, BookAuthorQueryRepository>();
        services.AddScoped<IBookCategoryCommandRepository, BookCategoryCommandRepository>();
        services.AddScoped<IBookCategoryQueryRepository, BookCategoryQueryRepository>();
        services.AddScoped<IBookPublisherCommandRepository, BookPublisherCommandRepository>();
        services.AddScoped<IBookPublisherQueryRepository, BookPublisherQueryRepository>();
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<IFineCommandRepository, FineCommandRepository>();
        services.AddScoped<IFineQueryRepository, FineQueryRepository>();
        services.AddScoped<ILoanCommandRepository, LoanCommandRepository>();
        services.AddScoped<ILoanQueryRepository, LoanQueryRepository>();
        services.AddScoped<IMemberCommandRepository, MemberCommandRepository>();
        services.AddScoped<IMemberQueryRepository, MemberQueryRepository>();
        services.AddScoped<IPublisherCommandRepository, PublisherCommandRepository>();
        services.AddScoped<IPublisherQueryRepository, PublisherQueryRepository>();
        services.AddScoped<IReservationCommandRepository, ReservationCommandRepository>();
        services.AddScoped<IReservationQueryRepository, ReservationQueryRepository>();
        const string serviceName = "StarterKit.Api";

       
        services.AddOpenTelemetry()
            .ConfigureResource(resource =>
                resource.AddService(serviceName))
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter();
            })
            .WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddOtlpExporter();
            });



        return services;
    }
}