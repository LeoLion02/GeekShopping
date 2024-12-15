using FluentValidation.Results;
using System.Net;

namespace GeekShopping.ProductAPI.Models.Common;

public class Result
{
    protected Result() { }
    protected Result(string errorMessage, HttpStatusCode statusCode)
    {
        IsFailure = true;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public bool IsFailure { get; init; }
    public string? ErrorMessage { get; init; }
    public HttpStatusCode? StatusCode { get; init; }

    public static Result Success()
        => new();

    public static Result Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(errorMessage, statusCode);

    public static Result Failure(ValidationResult validationResult)
        => new(validationResult.Errors.First().ErrorMessage, HttpStatusCode.BadRequest);
}

public class Result<TValue> : Result where TValue : class
{
    private Result(TValue value) { Value = value; }

    protected Result(string errorMessage, HttpStatusCode statusCode)
        : base(errorMessage, statusCode) { }

    public TValue? Value { get; init; }

    public static Result<TValue> Success(TValue value)
        => new(value);

    public static new Result<TValue> Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(errorMessage, statusCode);

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);
}
