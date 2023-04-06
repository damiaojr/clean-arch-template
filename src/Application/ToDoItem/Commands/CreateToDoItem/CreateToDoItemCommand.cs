using MediatR;
using OI.Template.Domain.Events;

namespace OI.Template.Application.ToDoItem.Commands.CreateToDoItem;

public record CreateToDoItemCommand : IRequest<Guid>
{
    public Guid ListId { get; set; }
    public string? Title { get; set; }
};

public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ToDoItem
        {
            ListId = request.ListId,
            Title = request.Title
        };
        
        entity.AddDomainEvent(new ToDoItemCreatedEvent(entity));

        entity.Id = Guid.NewGuid();

        return entity.Id;
    }
}