using CryptoQuotation.Service.Application.Common;
using OneOf.Types;
using OneOf;
using Microsoft.Extensions.Logging;
using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.DataContracts.Contracts;

namespace CryptoQuotation.Service.Application.Features.GetCryptoQuotations;

public class GetCryptoQuoteHandler : QueryHandler<GetCryptoQuoteQuery, OneOf<CryptoModel, NotFound>>
{
    private readonly ICryptoServices _cryptoServices;

    public GetCryptoQuoteHandler(
        ILogger<GetCryptoQuoteHandler> logger,
        ICryptoServices cryptoServices)
        : base(logger)
    {
        _cryptoServices = cryptoServices;
    }

    protected override async Task<OneOf<CryptoModel, NotFound>> HandleRequest(GetCryptoQuoteQuery query, CancellationToken cancellationToken)
    {
        var result = await _cryptoServices.GetQuoteCurrenciesAsync(query.Ticker);
        if (result == null)
        {
            return new NotFound();
        }

        // TODO should delegate and use automapper :P
        var model = new CryptoModel
        {
            Ticker = result.Ticker
        };

        foreach (var item in result.QuoteCurrencies)
        {
            model.QuoteCurrencies.Add(new QuoteModel
            {
                Currency = item.Currency,
                Value = item.Value
            });
        }
            
        return model;
    }
}