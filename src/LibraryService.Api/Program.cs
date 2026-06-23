using FastCqrs;
using FastCqrs.DependencyInjection;
using LibraryService.Api.Domain.Abstraction.Decoders;
using LibraryService.Api.Features.Author;
using LibraryService.Api.Features.Book;
using LibraryService.Api.Features.BookAuthor;
using LibraryService.Api.Features.BookCategory;
using LibraryService.Api.Features.BookPublisher;
using LibraryService.Api.Features.Category;
using LibraryService.Api.Features.Fine;
using LibraryService.Api.Features.Loan;
using LibraryService.Api.Features.Member;
using LibraryService.Api.Features.Publisher;
using LibraryService.Api.Features.Reservation;
using LibraryService.Api.Health;
using LibraryService.Api.Infrastructure.Observability;
using LibraryService.Api.Middlewares;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddApiInfrastructure(builder.Configuration);
builder.Services.AddApplicationObservability(builder.Configuration);
builder.Services.AddApiHealthChecks();

builder.Services.AddFastCqrs(options =>
    options.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(LoggingDecorator<,>));
builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(CachingDecorator<,>));
builder.Logging.ClearProviders();

builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeFormattedMessage = true;
    options.IncludeScopes = true;
    options.ParseStateValues = true;

    options.SetResourceBuilder(
        ResourceBuilder.CreateDefault()
            .AddService("LibraryService"));

    options.AddOtlpExporter();
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.MapApiHealthChecks();
app.MapAuthorEndpoints();
app.MapBookEndpoints();
app.MapBookAuthorEndpoints();
app.MapBookCategoryEndpoints();
app.MapBookPublisherEndpoints();
app.MapCategoryEndpoints();
app.MapFineEndpoints();
app.MapLoanEndpoints();
app.MapMemberEndpoints();
app.MapPublisherEndpoints();
app.MapReservationEndpoints();
app.Run();
public partial class Program
{
}