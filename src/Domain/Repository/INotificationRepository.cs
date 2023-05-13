using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Repository;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAllAsync();
    Task<Notification?> GetByIdAsync(Guid id);
    Task<Notification> CreateAsync(Notification notification);
}