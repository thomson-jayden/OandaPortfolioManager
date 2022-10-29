using OandaPortfolioManager.Configuration;
using OandaPortfolioManager.Models;
using OandaPortfolioManager.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static OandaPortfolioManager.Configuration.InternalConstants;

namespace OandaPortfolioManager.Services;

public class OandaService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OandaService(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task<Result<decimal>> GetAccountBalance(string accountNumber)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(OandaClient.ClientName);
            var httpResponse = await client.GetAsync(string.Format(OandaClient.AccountUrl, accountNumber));

            if (httpResponse.IsSuccessStatusCode)
            {
                var body = await httpResponse.Content.ReadAsStringAsync();

                var accountSummary = JsonSerializer.Deserialize<OandaAccountsResponse>(body);
                return new SuccessResult<decimal>(Convert.ToDecimal(accountSummary.account.balance));
            }
            else
            {
                if (httpResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                    return new FailureResult<decimal>(new RetriableHttpError());
                else
                    return new FailureResult<decimal>(new CommunicationException());
            }
        }
        catch (Exception ex)
        {
            return new FailureResult<decimal>(new CommunicationException("Unexpected error occured", ex));
        }
    }

    public async Task<Result<decimal>> GetPreviousAccountBalance(string accountNumber, )
    {

    }
}
