using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace OandaPortfolioManager.Functions;

public class BatchProfitLossAnalysis
{
    [FunctionName(nameof(BatchProfitLossAnalysis))]
    public void Run([TimerTrigger("0 0 7 * * 6")]TimerInfo myTimer, ILogger log)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
}
