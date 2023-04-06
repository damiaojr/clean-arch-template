using MediatR;
using Microsoft.Extensions.Logging;
using OI.Template.Domain.Events;

namespace OI.Template.Application.ToDoItem.EventHandlers;

public class ToDoItemDeletedEventHandler : INotificationHandler<ToDoItemDeletedEvent>
{
    private readonly ILogger<ToDoItemDeletedEventHandler> _logger;

    public ToDoItemDeletedEventHandler(ILogger<ToDoItemDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ToDoItemDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}