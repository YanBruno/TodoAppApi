namespace TodoApp.Core.Src.Commands.Contracts;

public interface ICommandResult
{
    string Message { get; }
    bool Success { get; }
    object? Data { get; }
}