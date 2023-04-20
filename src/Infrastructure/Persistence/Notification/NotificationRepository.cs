using OI.Template.Domain.Repository;
using OI.Template.Infrastructure.Configuration;

namespace OI.Template.Infrastructure.Persistence.Notification;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotificationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.Entities.Notification> InsertNotificationAsync(Domain.Entities.Notification notification)
    {
        _dbContext.Notifications.Add(notification);
        await _dbContext.SaveChangesAsync();
        return notification;
    }
}