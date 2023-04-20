using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Repository;

public interface INotificationRepository
{
    Task<Notification> InsertNotificationAsync(Notification notification);
}