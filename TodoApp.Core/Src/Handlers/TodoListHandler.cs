using TodoApp.Core.Src.Commands.Contracts;
using TodoApp.Core.Src.Commands.In.TodoListCommands;
using TodoApp.Core.Src.Handlers.Contracts;

namespace TodoApp.Core.Src.Handlers;

public class TodoListHandler
    : IHandler<CreateNewTodoListCommand>
    , IHandler<DeleteTodoListCommand>
    , IHandler<UpdateTodoListCommand>
{
    public Task<ICommandResult> HandleAsync(CreateNewTodoListCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> HandleAsync(UpdateTodoListCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> HandleAsync(DeleteTodoListCommand command)
    {
        throw new NotImplementedException();
    }
}