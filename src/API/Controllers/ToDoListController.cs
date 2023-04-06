using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.ToDoList.Commands.CreateToDoList;
using OI.Template.Application.ToDoList.Commands.DeleteToDoList;

namespace OI.Template.API.Controllers;

public class ToDoListController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateToDoListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteToDoListCommand(id));
        return NoContent();
    }
}