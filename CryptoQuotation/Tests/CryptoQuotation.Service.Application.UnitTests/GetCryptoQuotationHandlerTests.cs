using AutoFixture;
using CryptoQuotation.Service.Application.Features.GetCryptoQuotations;
using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.DataContracts.Contracts;
using Microsoft.Extensions.Logging;
using OneOf.Types;

namespace CryptoQuotation.Service.Application.UnitTests
{
    public class GetCryptoQuotationHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<ILogger<GetCryptoQuoteHandler>> _logger = new();
        private readonly GetCryptoQuoteHandler _handler;
        private readonly Mock<ICryptoServices> _repo = new();

        public GetCryptoQuotationHandlerTests()
        {
            _fixture = new Fixture();
            _handler = new GetCryptoQuoteHandler(_logger.Object, _repo.Object);
        }

        [Fact]
        public async Task Given_GetCryptoQuotationQuery_For_ValidTicker_Handle_Returns_CryptoModel()
        {
            // Arrange
            var cryptoQuotation = _fixture.Create<Entities.CryptoQuote>();

            _repo
                .Setup(x => x.GetQuoteCurrenciesAsync(It.IsAny<string>()))
                .ReturnsAsync(cryptoQuotation);

            // Act
            var result =
                await _handler.Handle(new GetCryptoQuoteQuery { Ticker = cryptoQuotation.Ticker }, CancellationToken.None);

            // Assert
            ((CryptoModel)result.Value).Ticker.Should().Be(cryptoQuotation.Ticker);
            result.Value.GetType().Should().Be(typeof(CryptoModel));
            _repo.Verify(x => x.GetQuoteCurrenciesAsync(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task Given_GetCryptoQuotationQuery_For_InvalidTicker_Handle_Returns_NotFound()
        {
            // Arrange
            var ticker = _fixture.Create<string>();

            _repo
                .Setup(x => x.GetQuoteCurrenciesAsync(It.IsAny<string>()))
                .ReturnsAsync((Entities.CryptoQuote?)null);

            // Act
            var result = await _handler.Handle(new GetCryptoQuoteQuery()
                { Ticker = ticker}, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
            result.Value.GetType().Should().Be(typeof(NotFound));
        }
    }
}