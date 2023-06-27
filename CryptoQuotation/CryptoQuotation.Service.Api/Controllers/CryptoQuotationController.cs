using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuotation.Service.Api.Controllers;

[Route("api/{controller}/{id}")]
public class CryptoQuotationController : AbstractController
{
    public CryptoQuotationController(
        ILogger<CryptoQuotationController> logger, 
        IMediator mediator)
        : base(logger, mediator)
    { }

    [HttpGet]
    public Task<IActionResult> Get(string id)
    {
        throw new NotImplementedException();
    }
}
