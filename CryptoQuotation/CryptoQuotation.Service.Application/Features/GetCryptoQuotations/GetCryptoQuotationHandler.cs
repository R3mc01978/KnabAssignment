using CryptoQuotation.Service.Application.Common;
using OneOf.Types;
using OneOf;
using CryptoQuotation.Service.DataContracts;
using Microsoft.Extensions.Logging;
using CryptoQuotation.Service.Application.Interfaces;

namespace CryptoQuotation.Service.Application.Features.GetCryptoQuotations
{
    public class GetCryptoQuotationHandler : QueryHandler<GetCryptoQuotationQuery, OneOf<CryptoModel, NotFound>>
    {
        private readonly ICryptoServices _cryptoServices;

        public GetCryptoQuotationHandler(
            ILogger<GetCryptoQuotationHandler> logger,
            ICryptoServices cryptoServices)
            : base(logger)
        {
            _cryptoServices = cryptoServices;
        }

        protected override async Task<OneOf<CryptoModel, NotFound>> HandleRequest(GetCryptoQuotationQuery query, CancellationToken cancellationToken)
        {
            var result = await _cryptoServices.GetQuotationsAsync(query.Ticker);
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
                model.QuoteCurrencies.Add(new QuotationModel
                {
                    Currency = item.Currency,
                    Value = item.Value
                });
            }
            
            return model;
        }
    }
}
