using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.Notification.Commands;
using OI.Template.Application.Notification.Commands.SendPushNotification;
using OI.Template.Application.Notification.Queries;
using OI.Template.Contract;

namespace OI.Template.API.Controllers;

public class NotificationController : ApiControllerBase
{
    private readonly IMapper _mapper;

    public NotificationController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Notification>> Post(Notification notification)
    {
        var createdNotification = await Mediator.Send(_mapper.Map<PushNotificationCommand>(notification));
        var createdUrl = Url.Link("/api/v1/notification", new { id = createdNotification.Id });
        return Created(createdUrl, notification);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Notification>> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetNotificationQuery { Id = id });
        return _mapper.Map<Notification>(result);
    }
}