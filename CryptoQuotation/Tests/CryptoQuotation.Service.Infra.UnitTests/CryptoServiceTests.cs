using System.Text.Json;
using CryptoQuotation.Service.Infra.Services;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;
using Microsoft.Extensions.Options;

namespace CryptoQuotation.Service.Infra.UnitTests
{
    public class CryptoServiceTests
    {
        [Fact]
        public void Given_GetQuoteCurrenciesAsync_WithoutConfigurationSpecified_Throws_InvalidOperationException()
        {
            // Arrange
            var options = Options.Create(new CryptoServiceSettings());
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<IOptions<CryptoServiceSettings>>();
            configurationMock.Setup(x => x.Value).Returns(new CryptoServiceSettings());

            // Act
            var act = () => new CryptoService(httpClientMock.Object, options);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestSerialize()
        {
            // Arrange
            const string expectedJson = "{\"data\":{\"BTC\":[{\"name\":\"Bitcoin\",\"symbol\":\"BTC\",\"quote\":{\"USD\":{\"price\":123}}}]},\"status\":{\"error_message\":\"\"}}";

            var data = new CoinCapResponseModel
            {
                Data = new Dictionary<string, List<LatestQuote>>()
                {
                    {
                        "BTC", new List<LatestQuote>()
                        {
                            new()
                            {
                                Symbol = "BTC",
                                Name = "Bitcoin",
                                Quote = new Dictionary<string, Quote>
                                {
                                    {
                                        "USD",
                                        new Quote()
                                        {
                                            Price = 123
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var json = JsonSerializer.Serialize(data);

            // Assert
            json.Should().NotBe(null);
            json.Should().Be(expectedJson);
        }

        [Fact]
        public void TestDeserialize()
        {
            // Arrange
            const string json = "{\"data\":{\"BTC\":[{\"name\":\"Bitcoin\",\"symbol\":\"BTC\",\"quote\":{\"USD\":{\"price\":123}}}]},\"status\":{\"error_message\":\"\"}}";

            // Act
            var deserialised = JsonSerializer.Deserialize<CoinCapResponseModel>(json);

            // Assert
            deserialised.Should().NotBe(null);
            deserialised!.Data.First().Key.Should().Be("BTC");
        }
    }
}