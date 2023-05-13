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
        notification = _mapper.Map<Notification>(createdNotification);
        return CreatedAtAction(nameof(GetById), new { id = createdNotification.Id }, notification);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Notification>> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetNotificationByIdQuery { Id = id });
        return _mapper.Map<Notification>(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notification>>> Get()
    {
        var result = await Mediator.Send(new GetAllNotificationsQuery());
        return _mapper.ProjectTo<Notification>(result.AsQueryable()).ToList();
    }
}