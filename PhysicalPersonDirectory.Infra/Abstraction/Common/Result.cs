namespace PhysicalPersonDirectory.Infra.Abstraction.Common;

public class Result(bool success, object? data)
{
    public bool Success { get; init ; } = success;
    public object? Data { get; init; } = data;
}