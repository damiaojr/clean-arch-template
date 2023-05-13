using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OI.Template.Domain.Repository;
using OI.Template.Infrastructure.Configuration;
using OI.Template.Infrastructure.Persistence;
using OI.Template.Infrastructure.Persistence.Notification;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });

        serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        serviceCollection.AddScoped<ApplicationDbContextInitializer>();
        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
        serviceCollection.AddScoped<IBlobStorageRepository, AzureBlobRepository>();
        
        serviceCollection.Configure<AzureConfiguration>(configuration.GetSection("AzureConfiguration"));
        serviceCollection.AddSingleton<IBlobStorageRepository, AzureBlobRepository>();
            
        return serviceCollection;
    }
}