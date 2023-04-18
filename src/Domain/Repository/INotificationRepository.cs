using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Repository;

public interface INotificationRepository
{
    Task<Guid> InsertNotification(Notification notification);
}