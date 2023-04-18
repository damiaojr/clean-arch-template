using OI.Template.Domain.Entities;
using OI.Template.Domain.Repository;

namespace OI.Template.Infrastructure.Persistence;

public class NotificationRepository : INotificationRepository
{
    public async Task<Guid> InsertNotification(Notification notification)
    {
        throw new NotImplementedException();
    }
}