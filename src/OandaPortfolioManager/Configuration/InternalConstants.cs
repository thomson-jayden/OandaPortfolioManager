namespace OandaPortfolioManager.Configuration;

public static class InternalConstants
{
    public static class OandaClient
    {
        public static string ClientName = nameof(OandaClient);
        public static string BaseUrl = "https://api-fxtrade.oanda.com/v3/";
        public static string AccountUrl = "accounts/{0}/summary";
    }
}
