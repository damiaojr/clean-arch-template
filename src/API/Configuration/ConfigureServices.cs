using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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
        
        return serviceCollection;
    }

    public static IApplicationBuilder ConfigureHealthCheck(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health");
        return app;
    }
}