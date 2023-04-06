using MediatR;

namespace OI.Template.Application.ToDoList.Commands.CreateToDoList;

public record CreateToDoListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}

public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommand, Guid>
{
    public async Task<Guid> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ToDoList
        {
            Title = request.Title
        };

        entity.Id = Guid.NewGuid();
        return entity.Id;
    }
}