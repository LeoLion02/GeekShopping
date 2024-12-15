using System.Net;

namespace GeekShopping.CouponApi.Models.Common;

public class Result<TValue> where TValue : class
{
    private Result(TValue value)
    {
        Value = value;
    }

    private Result(string errorMessage, HttpStatusCode statusCode)
    {
        IsFailure = true;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public bool IsFailure { get; init; }
    public string? ErrorMessage { get; init; }
    public HttpStatusCode? StatusCode { get; init; }
    public TValue? Value { get; init; }

    public static Result<TValue> Success(TValue value)
        => new Result<TValue>(value);

    public static Result<TValue> Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new Result<TValue>(errorMessage, statusCode);

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);
}
