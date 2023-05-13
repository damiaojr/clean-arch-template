using Microsoft.EntityFrameworkCore;
using OI.Template.Domain.Repository;

namespace OI.Template.Infrastructure.Persistence.Notification;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotificationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Domain.Entities.Notification>> GetAllAsync()
    {
        return await _dbContext.Notifications
            .OrderBy(n => n.Title)
            .ToListAsync();
    }

    public async Task<Domain.Entities.Notification?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Notifications
            .FirstOrDefaultAsync(n => n.Id.Equals(id));
    }

    public async Task<Domain.Entities.Notification> CreateAsync(Domain.Entities.Notification notification)
    {
        _dbContext.Notifications.Add(notification);
        await _dbContext.SaveChangesAsync();
        return notification;
    }
}