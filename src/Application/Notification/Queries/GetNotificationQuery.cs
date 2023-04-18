using MediatR;

namespace OI.Template.Application.Notification.Queries;

public record GetNotificationQuery : IRequest<Domain.Entities.Notification>
{
    public Guid Id { get; set; }
}

public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, Domain.Entities.Notification>
{
    private static readonly Domain.Entities.Notification notification = new()
    {
        Title = "This is not a drill",
        Created = DateTime.Now.Date,
        CreatedBy = "damiao"
    };
    
    public async Task<Domain.Entities.Notification> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
    {
        notification.Id = request.Id;
        return notification;
    }
}