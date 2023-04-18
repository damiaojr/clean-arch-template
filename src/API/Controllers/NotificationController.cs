using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.Notification.Commands;
using OI.Template.Application.Notification.Queries;
using OI.Template.Contract;

namespace OI.Template.API.Controllers;

public class NotificationController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Post(Notification notification)
    {
        return await Mediator.Send(new PushNotificationCommand { Title = notification.Title });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Notification>> Get(Guid id)
    {
        var result = await Mediator.Send(new GetNotificationQuery { Id = id });
        return new Notification
        {
            Id = result.Id,
            Title = result.Title,
        };
    }
}