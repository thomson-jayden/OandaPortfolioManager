using System;

namespace OandaPortfolioManager.Models;

public class Result
{
    public State State { get; set; }
    public Exception Exception { get; set; }
}

public class Result<T> : Result
{
    public T Value { get; set; }
}

public class SuccessResult : Result
{
    public SuccessResult()
    {
        State = State.Success;
        Exception = null;
    }
}

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T value)
    {
        State = State.Success;
        Exception = null;
        Value = value;
    }
}

public class FailureResult : Result
{
    public FailureResult(Exception exception)
    {
        State = State.Failure;
        Exception = exception;
    }
}

public class FailureResult<T> : Result<T>
{
    public FailureResult(Exception exception)
    {
        State = State.Success;
        Exception = exception;
        Value = default;
    }
}

public enum State
{
    Success,
    Failure
}