using MediatR;
using OI.Template.Domain.Events;
using Microsoft.Extensions.Logging;

namespace OI.Template.Application.ToDoItem.EventHandlers;

public class ToToItemCreatedEventHandler : INotificationHandler<ToDoItemCreatedEvent>
{
    private readonly ILogger<ToToItemCreatedEventHandler> _logger;

    public ToToItemCreatedEventHandler(ILogger<ToToItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ToDoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}