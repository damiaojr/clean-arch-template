using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Events.NotificationEvents;

public class SendNotificationEvent : BaseEvent
{
    public Notification Notification { get; }
    
    public SendNotificationEvent(Notification notification)
    {
        this.Notification = notification;
    }
}