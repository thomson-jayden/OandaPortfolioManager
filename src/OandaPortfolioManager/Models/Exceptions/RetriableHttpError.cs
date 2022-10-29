using System;

namespace OandaPortfolioManager.Models.Exceptions;

public class RetriableHttpError : Exception
{
    public RetriableHttpError()
    {
    }

    public RetriableHttpError(string message)
        : base(message)
    {
    }

    public RetriableHttpError(string message, Exception inner)
        : base(message, inner)
    {
    }
}
