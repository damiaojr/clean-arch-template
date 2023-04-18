using MediatR;
using OI.Template.Domain.Events.NotificationEvents;

namespace OI.Template.Application.Notification.Commands;

public record PushNotificationCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}

public class PushNotificationCommandHandler : IRequestHandler<PushNotificationCommand, Guid>
{
    public async Task<Guid> Handle(PushNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Notification
        {
            Title = "This is not a drill",
            Created = DateTime.Now,
            CreatedBy = "Damiao"
        };
        
        entity.AddDomainEvent(new SendNotificationEvent(entity));

        entity.Id = Guid.NewGuid();

        return entity.Id;
    }
}