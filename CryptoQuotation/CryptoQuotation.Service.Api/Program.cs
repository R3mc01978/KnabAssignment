using CryptoQuotation.Service.Api;
using CryptoQuotation.Service.Application;
using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.Infra;
using CryptoQuotation.Service.Infra.Services;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CryptoServiceSettings>(builder.Configuration.GetSection("CryptoServiceSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerFor();
builder.Services.AddInfrastructure();
builder.Services.AddApplication(typeof(Program).Assembly);


builder.Services.AddHttpClient<ICryptoServices, CryptoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
