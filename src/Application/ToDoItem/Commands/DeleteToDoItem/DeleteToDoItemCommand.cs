using MediatR;
using OI.Template.Domain.Events;

namespace OI.Template.Application.ToDoItem.Commands.DeleteToDoItem;

public record DeleteToDoItemCommand(Guid Id) : IRequest;

public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
{
    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ToDoItem
        {
            Id = request.Id
        };

        entity.AddDomainEvent(new ToDoItemDeletedEvent(entity));
    }
}