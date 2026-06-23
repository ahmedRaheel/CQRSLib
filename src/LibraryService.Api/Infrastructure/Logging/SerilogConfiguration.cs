using Microsoft.Extensions.Configuration;
using Serilog;

namespace LibraryService.Api.Infrastructure.External.Logging.Serilog;
public static class SerilogConfiguration
{
    public static LoggerConfiguration ConfigureSerilog(this LoggerConfiguration cfg, IConfiguration configuration) => cfg.ReadFrom.Configuration(configuration).Enrich.FromLogContext().Enrich.WithMachineName().Enrich.WithEnvironmentName();
}