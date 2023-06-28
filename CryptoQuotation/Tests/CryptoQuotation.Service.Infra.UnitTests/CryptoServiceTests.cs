using CryptoQuotation.Service.Infra.Services;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;

namespace CryptoQuotation.Service.Infra.UnitTests
{
    public class CryptoServiceTests
    {
        [Fact]
        public void Given_GetQuoteCurrenciesAsync_WithoutConfigurationSpecified_Throws_InvalidOperationException()
        {
            var someOptions = Options.Create(new CryptoServiceSettings());

            // Arrange
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<IOptions<CryptoServiceSettings>>();
            configurationMock.Setup(x => x.Value).Returns(new CryptoServiceSettings());
            
            // Act
            var act = () => new CryptoService(httpClientMock.Object, someOptions);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}