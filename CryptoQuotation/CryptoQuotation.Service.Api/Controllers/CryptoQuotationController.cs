using CryptoQuotation.Service.Application.Features.GetCryptoQuotations;
using CryptoQuotation.Service.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CryptoQuotation.Service.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/quotations")]
public class CryptoQuotationController : AbstractController
{
    /// <summary>
    /// ctor    
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CryptoQuotationController(
        ILogger<CryptoQuotationController> logger, 
        IMediator mediator)
        : base(logger, mediator)
    { }

    /// <summary>
    /// Returns quote currencies for the specified ticker
    /// </summary>
    /// <param name="ticker">the ticker / code of the crypto</param>
    /// <returns>a list of quote currencies</returns>
    [HttpGet("{ticker}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the ticker and its related quote currencies. (e.g. BTC)", Type = typeof(CryptoModel))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "no quote currencies could be found for the specified ticker")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error")]
    public async Task<IActionResult> Get(string ticker)
    {
        var result = await Mediator.Send(new GetCryptoQuotationQuery { Ticker = ticker });

        return result.Match<IActionResult>(
            _ => Ok(result.Value),
            _ => NotFound(result.Value));
    }
}
