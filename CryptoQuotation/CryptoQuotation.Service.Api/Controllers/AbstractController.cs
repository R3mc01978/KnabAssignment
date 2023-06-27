using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuotation.Service.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public abstract class AbstractController : ControllerBase
{
    protected readonly ILogger Logger;
    protected IMediator Mediator { get; }
    protected AbstractController(ILogger logger, IMediator mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }
}