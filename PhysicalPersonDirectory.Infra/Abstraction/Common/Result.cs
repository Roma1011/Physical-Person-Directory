namespace PhysicalPersonDirectory.Infra.Abstraction.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? ErrorMessage { get; }
    public int? StatusCode { get; }

    public Result(bool isSuccess, T? value, string? errorMessage,int? statusCode)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }
}