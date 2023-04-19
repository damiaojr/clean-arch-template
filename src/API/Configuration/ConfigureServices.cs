using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using AutoMapper;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHealthChecks();
        serviceCollection.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
        });

        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        return serviceCollection;
    }

    public static IApplicationBuilder ConfigureHealthCheck(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";

                var response = new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(entry => new
                    {
                        name = entry.Key,
                        status = entry.Value.Status.ToString(),
                        description = entry.Value.Description
                    })
                };

                await context.Response.WriteAsJsonAsync(response);
            },
            ResultStatusCodes =
            {
                [HealthStatus.Unhealthy] = 503,
                [HealthStatus.Degraded] = 429,
                [HealthStatus.Healthy] = 200,
            }
        });
        return app;
    }
}