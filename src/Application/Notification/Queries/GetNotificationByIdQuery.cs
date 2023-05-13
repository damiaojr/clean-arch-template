using MediatR;
using OI.Template.Application.Exceptions;
using OI.Template.Domain.Repository;

namespace OI.Template.Application.Notification.Queries;

public record GetNotificationByIdQuery : IRequest<Domain.Entities.Notification>
{
    public Guid Id { get; set; }
}

public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Domain.Entities.Notification>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationByIdQueryHandler(INotificationRepository notificationRepository) => _notificationRepository = notificationRepository;

    public async Task<Domain.Entities.Notification> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetByIdAsync(request.Id);

        if (notification is null)
            throw new NotFoundException(nameof(Domain.Entities.Notification), request.Id);

        return notification;
    }
}