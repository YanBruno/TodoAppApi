using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.Out;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult()
    {
    }

    public GenericCommandResult(string message, bool success, object? data)
    {
        Message = message;
        Success = success;
        Data = data;
    }

    public string Message { get; set; } = null!;

    public bool Success { get; set; }

    public object? Data { get; set; }
}