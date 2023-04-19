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
    public async Task<ActionResult<Guid>> Post(Notification notification)
    {
        return await Mediator.Send(_mapper.Map<PushNotificationCommand>(notification));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Notification>> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetNotificationQuery { Id = id });
        return _mapper.Map<Notification>(result);
    }
}