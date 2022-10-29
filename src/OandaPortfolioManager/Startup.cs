using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using OandaPortfolioManager.Models;
using System;
using System.Runtime;
using OandaPortfolioManager.Configuration;

[assembly: FunctionsStartup(typeof(OandaPortfolioManager.Startup))]

namespace OandaPortfolioManager;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddOptions<ProfitLossAnalysisRequest>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection(nameof(ProfitLossAnalysisRequest)).Bind(settings);
            });

        builder.Services.AddHttpClient(InternalConstants.OandaClient.ClientName, httpClient =>
        {
            httpClient.BaseAddress = new Uri(InternalConstants.OandaClient.BaseUrl);
        });
    }
}