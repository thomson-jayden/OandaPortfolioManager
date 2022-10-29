namespace OandaPortfolioManager.Models;

public class ProfitLossAnalysisRequest
{
    public string AnalysisAccount { get; set; }
    public decimal GrowthTargetPercentage { get; set; }
    public string SurplusAccount { get; set; }
    public string ReportEmail { get; set; }
    public int AnalysisPeriodInDays{ get; set; }
    public string OandaPatKeyVaultUri { get; set; }
}
