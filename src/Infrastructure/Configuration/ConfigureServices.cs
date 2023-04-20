using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OI.Template.Domain.Repository;
using OI.Template.Infrastructure.Configuration;
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

        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
            
        return serviceCollection;
    }
}