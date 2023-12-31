﻿using System.Net.Http.Headers;
using System.Web;
using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap;

public class CryptoService : ICryptoServices
{
    private readonly HttpClient _httpClient;
    private readonly CryptoServiceSettings _configuration;

    public CryptoService(HttpClient httpClient, IOptions<CryptoServiceSettings> configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration.Value;

        if (string.IsNullOrEmpty(_configuration.Url) ||
            string.IsNullOrEmpty(_configuration.ApiKey) ||
            string.IsNullOrEmpty(_configuration.Currencies))
        {
            throw new InvalidOperationException("No configuration specified");
        }
    }

    public async Task<Application.Entities.CryptoQuote?> GetQuoteCurrenciesAsync(string ticker)
    {
        var currencies = _configuration.Currencies.Split(',');
        var tasks = new Task<string?>[currencies.Length];

        // Free API plan does not support multiple currency symbols for the convert option. :(
        for (var index = 0; index < currencies.Length; index++)
        {
            var currency = currencies[index];
            tasks[index] = GetData(ticker, currency);
        }

        var responses = await Task.WhenAll(tasks);
        var data = responses.Where(r => r != null);
        var result = new Application.Entities.CryptoQuote(ticker);

        foreach (var json in data)
        {
            if (json == null) continue;

            var model = JsonConvert.DeserializeObject<CoinCapResponse>(json);
            if (model == null) continue;
            
            var latest = model.Data.First();
            if (!latest.Value.Any()) continue;

            // For now we fetch the first match
            var quote = latest.Value.First().Quote.First();

            result.AddQuoteCurrency(quote.Key, quote.Value.Price);
        }

        return result;
    }

    private async Task<string?> GetData(string ticker, string currencySymbol)
    {
        var url = new UriBuilder(_configuration.Url);

        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["symbol"] = ticker;
        queryString["convert"] = currencySymbol;

        url.Query = queryString.ToString();

        using var request = new HttpRequestMessage();
        request.Method = new HttpMethod("GET");
        request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
        request.Headers.Add("X-CMC_PRO_API_KEY", _configuration.ApiKey);
        request.RequestUri = new Uri(url.ToString());

        using var response = await _httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return null;
    }
}