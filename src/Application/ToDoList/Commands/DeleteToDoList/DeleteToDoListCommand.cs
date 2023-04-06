using MediatR;

namespace OI.Template.Application.ToDoList.Commands.DeleteToDoList;

public record DeleteToDoListCommand(Guid Id) : IRequest;

public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand>
{
    public async Task Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ToDoList
        {
            Id = request.Id
        };
    }
}