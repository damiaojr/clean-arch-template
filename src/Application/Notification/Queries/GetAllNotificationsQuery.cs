using MediatR;
using OI.Template.Domain.Repository;

namespace OI.Template.Application.Notification.Queries;

public record GetAllNotificationsQuery : IRequest<IEnumerable<Domain.Entities.Notification>>;

public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQuery, IEnumerable<Domain.Entities.Notification>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetAllNotificationsQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Notification>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notificationCollection = await _notificationRepository.GetAllAsync();
        return notificationCollection;
    }
}