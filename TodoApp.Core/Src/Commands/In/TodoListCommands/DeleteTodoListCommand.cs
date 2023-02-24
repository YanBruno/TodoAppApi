using TodoApp.Core.Src.Commands.Contracts;

namespace TodoApp.Core.Src.Commands.In.TodoListCommands;

public class DeleteTodoListCommand : ICommand
{
    public Guid? CustomerId { get; set; }
    public Guid? TodoListId { get; set; }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}