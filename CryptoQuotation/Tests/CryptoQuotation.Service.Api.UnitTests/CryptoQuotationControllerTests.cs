using CryptoQuotation.Service.Api.Controllers;
using CryptoQuotation.Service.Application.Features.GetCryptoQuotations;
using CryptoQuotation.Service.DataContracts.Contracts;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OneOf.Types;

namespace CryptoQuotation.Service.Api.UnitTests
{
    public class CryptoQuotationControllerTests
    {
        private readonly CryptoQuotationController _controller;
        private readonly Mock<IMediator> _mediator = new();

        public CryptoQuotationControllerTests()
        {
            Mock<ILogger<CryptoQuotationController>> loggerMock = new();
            _controller = new CryptoQuotationController(loggerMock.Object, _mediator.Object);
        }

        [Fact]
        public async Task Given_Valid_Ticker_When_Get_Then_200OK_IsReturned()
        {
            // Arrange
            var ticker = "BTC";
            var  model = Mock.Of<CryptoModel>();

            _mediator
                .Setup(m => m.Send(It.IsAny<GetCryptoQuotationQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(model);

            // Act
            var result = (ObjectResult)await _controller.Get(ticker);

            // Assert
            _mediator.Verify(x => x.Send(It.IsAny<GetCryptoQuotationQuery>(), It.IsAny<CancellationToken>()));
            result.Value.Should().Be(model);
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Given_InValid_Ticker_When_Get_Then_404NotFound_IsReturned()
        {
            // Arrange
            var ticker = "BOGUS";

            _mediator
                .Setup(m => m.Send(It.IsAny<GetCryptoQuotationQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new NotFound());

            // Act
            var result = (ObjectResult)await _controller.Get(ticker);

            // Assert
            _mediator.Verify(x => x.Send(It.IsAny<GetCryptoQuotationQuery>(), It.IsAny<CancellationToken>()));
            result.StatusCode.Should().Be(404);
        }
    }
}