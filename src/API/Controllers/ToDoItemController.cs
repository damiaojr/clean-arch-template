using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.ToDoItem.Commands.CreateToDoItem;
using OI.Template.Application.ToDoItem.Commands.DeleteToDoItem;

namespace OI.Template.API.Controllers;

public class ToDoItemController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateToDoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteToDoItemCommand(id));
        return NoContent();
    }
}