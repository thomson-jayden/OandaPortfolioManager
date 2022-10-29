using System;

namespace OandaPortfolioManager.Models.Exceptions;

public class CommunicationException : Exception 
{
    public CommunicationException()
    {
    }

    public CommunicationException(string message)
        : base(message)
    {
    }

    public CommunicationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
