using AutoMapper;
using MediatR;
using OI.Template.Domain.Events.NotificationEvents;
using OI.Template.Domain.Repository;

namespace OI.Template.Application.Notification.Commands.SendPushNotification;

public record PushNotificationCommand : IRequest<Domain.Entities.Notification>
{
    public string? Title { get; set; }
}

public class PushNotificationCommandHandler : IRequestHandler<PushNotificationCommand, Domain.Entities.Notification>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    

    public PushNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Notification> Handle(PushNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entities.Notification>(request);
        
        entity.AddDomainEvent(new SendNotificationEvent(entity));

        return await _notificationRepository.InsertNotificationAsync(entity);
    }
}