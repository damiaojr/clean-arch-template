using Microsoft.AspNetCore.Mvc;
using MediatR;
using OI.Template.API.Filters;

namespace OI.Template.API.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}