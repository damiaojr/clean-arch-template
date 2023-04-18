using MediatR;
using Microsoft.Extensions.Logging;
using OI.Template.Domain.Events.NotificationEvents;

namespace OI.Template.Application.Notification.EventHandlers;

public class PushNotificationEventHandler : INotificationHandler<SendNotificationEvent>
{
    private readonly ILogger<PushNotificationEventHandler> _logger;

    public PushNotificationEventHandler(ILogger<PushNotificationEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SendNotificationEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}