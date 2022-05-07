using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
    private IMediator mediator;
    protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

}