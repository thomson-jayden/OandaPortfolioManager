using OandaPortfolioManager.Models;
using OandaPortfolioManager.Services;
using System;
using System.Threading.Tasks;

namespace OandaPortfolioManager.Handlers;

public class ProfitLossAnalysisHandler
{
    private readonly OandaService _oandaService;

    public ProfitLossAnalysisHandler(OandaService oandaService)
    {
        _oandaService = oandaService;
    }

    public async Task<Result> ProcessAsync(ProfitLossAnalysisRequest request)
    {
        var previousBalance = new SuccessResult<decimal>(Convert.ToDecimal(1.00));

        var currentBalance = await _oandaService.GetAccountBalance(request.AnalysisAccount);

        var accountChangePercentage = (currentBalance.Value / previousBalance.Value) - 1;

        var accountAmountDifference = currentBalance.Value - previousBalance.Value;

        var targetAchieved = accountAmountDifference >= request.GrowthTargetPercentage;

        if (targetAchieved)


        return new SuccessResult();
    }
}
