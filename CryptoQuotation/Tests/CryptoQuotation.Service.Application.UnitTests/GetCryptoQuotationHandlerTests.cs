using AutoFixture;
using CryptoQuotation.Service.Application.Features.GetCryptoQuotations;
using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.DataContracts.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using OneOf.Types;

namespace CryptoQuotation.Service.Application.UnitTests
{
    public class GetCryptoQuotationHandlerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<ILogger<GetCryptoQuotationHandler>> _logger = new();
        private readonly GetCryptoQuotationHandler _handler;
        private readonly Mock<ICryptoServices> _repo = new();

        public GetCryptoQuotationHandlerTests()
        {
            _fixture = new Fixture();
            _handler = new GetCryptoQuotationHandler(_logger.Object, _repo.Object);
        }

        [Fact]
        public async Task Given_GetCryptoQuotationQuery_For_ValidTicker_Handle_Returns_CryptoModel()
        {
            // Arrange
            var cryptoQuotation = _fixture.Create<Entities.CryptoQuotation>();

            _repo
                .Setup(x => x.GetQuoteCurrenciesAsync(It.IsAny<string>()))
                .ReturnsAsync(cryptoQuotation);

            // Act
            var result =
                await _handler.Handle(new GetCryptoQuotationQuery { Ticker = cryptoQuotation.Ticker }, CancellationToken.None);

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
                .ReturnsAsync((Entities.CryptoQuotation?)null);

            // Act
            var result = await _handler.Handle(new GetCryptoQuotationQuery()
                { Ticker = ticker}, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
            result.Value.GetType().Should().Be(typeof(NotFound));
        }
    }
}