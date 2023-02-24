using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> HandleAsync(T command);
}